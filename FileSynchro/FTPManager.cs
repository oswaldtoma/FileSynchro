using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;

namespace FileSynchro
{
    public class FTPManager
    { 
        readonly string ftpServerAddress, ftpUsername, ftpPassword;
        FtpClient ftpClient = new FtpClient();
        public FTPManager(string ftpServerAddress, string ftpUsername, string ftpPassword)
        {
            this.ftpServerAddress = ftpServerAddress;
            this.ftpUsername = ftpUsername;
            this.ftpPassword = ftpPassword;

            ftpClient = new FtpClient(ftpServerAddress, ftpUsername, ftpPassword);
        }

        public void uploadFile(string localfileToUploadAbsPath, string remotePath)
        {
            ftpClient.UploadFile(localfileToUploadAbsPath, remotePath, createRemoteDir: true);
        }

        public void downloadFile(string localDirectoryDestAbsPath, string remotePath)
        {
            ftpClient.DownloadFile(localDirectoryDestAbsPath + remotePath.Replace('/','\\'), remotePath);
        }
        public List<File> getRemoteFilesList()
        {
            FtpListItem[] remoteFilesList = ftpClient.GetListing(ftpClient.GetWorkingDirectory(), FtpListOption.Recursive);

            List<File> parsedFilesList = new List<File>();

            foreach (var item in remoteFilesList)
            {
                File file = new File();
                if(item.Type == FtpFileSystemObjectType.File)
                {
                    file.FileName = item.Name;
                    file.SHA1Checksum = item.GetHashCode().ToString();
                    file.FileLastModificationDate = item.Modified;
                    file.FileCreationDate = null;
                    file.FileExtension = item.Name.Substring(item.Name.LastIndexOf('.'), item.Name.Length - item.Name.LastIndexOf('.'));
                    file.FileSize = item.Size;
                    file.FileLocationAbsPath = item.FullName;
                    parsedFilesList.Add(file);
                }
            }
            return parsedFilesList;
        }
    }
}
