using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using FluentFTP;
using Microsoft.Identity.Client;

namespace FileSynchro
{
    public class FTPManager
    {
        readonly bool secureMode;
        readonly string ftpServerAddress, ftpUsername, ftpPassword;
        FtpClient ftpClient = new FtpClient();
        public FTPManager(string ftpServerAddress, string ftpUsername, string ftpPassword, bool secureMode = false)
        {
            this.ftpServerAddress = ftpServerAddress;
            this.ftpUsername = ftpUsername;
            this.ftpPassword = ftpPassword;
            this.secureMode = secureMode;

            ftpClient = new FtpClient(ftpServerAddress, ftpUsername, ftpPassword);
            ftpClient.SocketKeepAlive = true;
        }

        public async Task<bool> connect()
        {
            if (secureMode)
            {
                await ftpClient.AutoConnectAsync();
            }
            else
            {
                await ftpClient.ConnectAsync();
            }

            return ftpClient.IsConnected;
            
        }

        public async Task uploadFileAsync(string localfileToUploadAbsPath, string remotePath)
        { 
            await ftpClient.UploadFileAsync(localfileToUploadAbsPath, remotePath, createRemoteDir: true);
        }

        public void setModifiedTime(string path, DateTime time)
        {
            ftpClient.SetModifiedTime(path, time, FtpDate.Local);
        }

        public async Task downloadFileAsync(string localDirectoryDestAbsPath, string remotePath)
        {
            await ftpClient.DownloadFileAsync(localDirectoryDestAbsPath + remotePath.Replace('/','\\'), remotePath);
        }

        public void deleteFile(string absPathToFile)
        {
            ftpClient.DeleteFile(absPathToFile);
        }
        public async Task<List<File>> getFtpRemoteFilesList()
        {
            FtpListItem[] remoteFilesList = await ftpClient.GetListingAsync(ftpClient.GetWorkingDirectory(), FtpListOption.Recursive);

            List<File> parsedFilesList = new List<File>();

            foreach (var item in remoteFilesList)
            {
                File file = new File();
                if(item.Type == FtpFileSystemObjectType.File)
                {
                    file.FileName = item.Name;
                    file.FileLastModificationDate = item.Modified;
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
