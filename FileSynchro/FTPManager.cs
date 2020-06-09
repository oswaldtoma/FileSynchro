using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileSynchro
{
    public class FTPManager
    {

        private readonly string ftpServerAddress, ftpUsername, ftpPassword;
        public FTPManager(string ftpServerAddress, string ftpUsername, string ftpPassword)
        {
            this.ftpServerAddress = ftpServerAddress;
            this.ftpUsername = ftpUsername;
            this.ftpPassword = ftpPassword;
        }
        public void uploadFile(string fileToUploadPath)
        {
            WebRequest request = WebRequest.Create($"{ftpServerAddress}/{fileToUploadPath}");
            request.Method = WebRequestMethods.Ftp.UploadFile;

            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            byte[] fileContents;

            using (StreamReader sourceStream = new StreamReader(fileToUploadPath))
            {
                fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            }

            request.ContentLength = fileContents.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse()) { };
        }

        public void downloadFile(string localDirectoryDestPath, string fileToDownloadPath)
        {
            WebRequest request = WebRequest.Create($"{ftpServerAddress}/{fileToDownloadPath}");
            request.Method = WebRequestMethods.Ftp.DownloadFile;

            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            using (Stream responseStream = response.GetResponseStream())
            using (Stream fileStream = System.IO.File.Create($"{localDirectoryDestPath}/{fileToDownloadPath}"))
            {
                responseStream.CopyTo(fileStream);
            }
        }

        public File fileListRecordConverter(string listRecord)
        {
            List<File> files = new List<File>();
            File file = new File();
            var splitRecord = String.Join(" ", listRecord.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)).Split(' ').ToList();

            StringBuilder filename = new StringBuilder();
            for (int i = 8; i < splitRecord.Count; i++)
            {
                filename.Append($"{splitRecord[i]} ");
            }
            file.FileName = filename.ToString().TrimEnd();

            DateTime lastModificationDate = new DateTime();
            DateTime.TryParse($"{splitRecord[7]} {splitRecord[6]} {splitRecord[5]}", out lastModificationDate);
            file.FileLastModificationDate = lastModificationDate;

            file.FileExtension = file.FileName.Contains('.') ? file.FileName.Substring(file.FileName.LastIndexOf('.'), file.FileName.Length - file.FileName.LastIndexOf('.')) : null;

            file.FileSize = Convert.ToInt64(splitRecord[4]);

            //file.fileLocation 2do!!!

            return file;
        }

        public void getListOfAllRemoteFiles()
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServerAddress);
            request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            List<File> remoteFilesList = new List<File>();

            while (!reader.EndOfStream)
            {
                remoteFilesList.Add(fileListRecordConverter(reader.ReadLine()));
            }

            reader.Close();
            response.Close();
        }
    }
}
