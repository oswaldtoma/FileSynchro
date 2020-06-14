using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSynchro
{
    static public class Synchronization
    {
        static bool isInitialized = false;
        static string logVar = "";
        static string localDirToSync, ftpAddress, ftpUsername, ftpPassword;
        static public FileSynchroDbContext fileSynchroDb = new FileSynchroDbContext();
        static List<File> localFiles = new List<File>();
        static FTPManager ftpManager = null;

        static public string getSHA1Checksum(FileInfo file)
        {
            using (FileStream fs = file.OpenRead())
            {
                SHA1 sha = new SHA1Managed();
                return BitConverter.ToString(sha.ComputeHash(fs));
            }
        }
        static public void Log(string log)
        {
            logVar += DateTime.Now + log;
        }

        static public bool init(string localDirPath, string ftpAddr, string ftpLogin, string ftpPass)
        {
            localDirToSync = localDirPath;
            ftpAddress = ftpAddr;
            ftpUsername = ftpLogin;
            ftpPassword = ftpPass;

            ftpManager = new FTPManager(ftpAddress, ftpUsername, ftpPassword);

            fileSynchroDb.Database.CreateIfNotExists();
            Log("Init finished");

            isInitialized = true;

            return isInitialized;
        }

        static void scanLocalFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(localDirToSync);
            FileInfo[] files = directory.GetFiles("*", searchOption: SearchOption.AllDirectories);

            foreach (var file in files)
            {
                File tempFile = new File
                {
                    FileName = file.Name,
                    FileLastModificationDate = file.LastWriteTime,
                    FileExtension = file.Extension,
                    FileSize = file.Length,
                    FileLocationAbsPath = file.FullName
                };
                localFiles.Add(tempFile);
            }
        }

        static void updateRemoteFilesTable()
        {
            fileSynchroDb.RemoteFiles.RemoveRange(fileSynchroDb.RemoteFiles);

            foreach (var item in ftpManager.getFtpRemoteFilesList())
            {
                fileSynchroDb.RemoteFiles.Add(item);
            }
            fileSynchroDb.SaveChanges();
        }
        static public void synchronize()
        {
            if (isInitialized)
            {
                List<File> remoteFilesTable = fileSynchroDb.RemoteFiles.ToList();

                //Task.Run(() =>
                {
                    scanLocalFiles();

                    List<File> filesToUpload = new List<File>();
                    List<File> filesToDownload = new List<File>();

                    List<File> ftpRemoteFilesList = ftpManager.getFtpRemoteFilesList();

                    foreach (var remoteFile in remoteFilesTable)
                    {
                        foreach (var localFile in localFiles)
                        {
                            bool isSameFile = remoteFile.FileName == localFile.FileName;
                            bool hasRemoteFileSizeChanged = ftpRemoteFilesList.Find(x => x.FileName == remoteFile.FileName).FileSize != remoteFile.FileSize;
                            bool hasLocalFileSizeChanged = remoteFile.FileSize != localFile.FileSize;

                            if (isSameFile && hasRemoteFileSizeChanged)
                            {
                                filesToDownload.Add(remoteFile);
                            }
                            else if(isSameFile && hasLocalFileSizeChanged)
                            {
                                filesToUpload.Add(localFile);
                            }

                            if(localFiles.Find(x=>x.FileName == remoteFile.FileName) == null)
                            {
                                filesToDownload.Add(remoteFile);
                            }

                            if(remoteFilesTable.Find(x=>x.FileName == localFile.FileName) == null)
                            {
                                filesToUpload.Add(localFile);
                            }
                        }
                    }

                    foreach (var item in filesToUpload)
                    {
                        string remotePath = item.FileLocationAbsPath.Replace(localDirToSync, "");
                        ftpManager.uploadFile(item.FileLocationAbsPath, remotePath);
                    }

                    foreach (var remoteItem in filesToDownload)
                    {
                        ftpManager.downloadFile($"{localDirToSync}", remoteItem.FileLocationAbsPath);
                    }
                }//);

                updateRemoteFilesTable();

            }
        }
    }
}
