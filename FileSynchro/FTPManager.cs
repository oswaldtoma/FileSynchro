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
    }
}
