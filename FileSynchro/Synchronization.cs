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
        static public bool isInitialized { get; set; }
        static public string logVar { get; set; }
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
            logVar += "[" + DateTime.Now + "]" + " " + log + Environment.NewLine;
        }

        static public async Task init(string localDirPath, string ftpAddr, string ftpLogin, string ftpPass, bool secureMode = false)
        {
            localDirToSync = localDirPath;
            ftpAddress = ftpAddr;
            ftpUsername = ftpLogin;
            ftpPassword = ftpPass;

            ftpManager = new FTPManager(ftpAddress, ftpUsername, ftpPassword, secureMode);
            await ftpManager.connect();

            fileSynchroDb.Database.CreateIfNotExists();
            Log("Init finished");

            isInitialized = await ftpManager.connect();
            if(!isInitialized)
            {
                Log("Failed to connect with FTP server!");
            }
        }

        static void scanLocalFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(localDirToSync);
            FileInfo[] files = directory.GetFiles("*", searchOption: SearchOption.AllDirectories);
            Log("Started scanning local files...");
            localFiles.Clear();
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
                Log(tempFile.FileLocationAbsPath);
            }
        }

        static void updateRemoteFilesTable()
        {
            Log("Updating remote files table...");
            fileSynchroDb.RemoteFiles.RemoveRange(fileSynchroDb.RemoteFiles);

            foreach (var item in ftpManager.getFtpRemoteFilesList())
            {
                fileSynchroDb.RemoteFiles.Add(item);
            }
            fileSynchroDb.SaveChanges();
        }
        static public async Task synchronize()
        {
            if (isInitialized)
            {
                Log("Synchronizing...");
                List<File> remoteFilesTable = fileSynchroDb.RemoteFiles.ToList();

                await Task.Run(() =>
                {
                    scanLocalFiles();

                    List<File> filesToUpload = new List<File>();
                    List<File> filesToDownload = new List<File>();

                    List<File> ftpRemoteFilesList = ftpManager.getFtpRemoteFilesList();

                    List<File> ftpRemoteFilesToDelete = new List<File>();
                    List<File> localFilesToDelete = new List<File>();

                    #region update
                    foreach (var remoteFile in ftpRemoteFilesList)
                    {
                        File remoteFileTableRecord = remoteFilesTable.Find(x => x.FileLocationAbsPath == remoteFile.FileLocationAbsPath);
                        if (remoteFileTableRecord != null)
                        {
                            if (remoteFileTableRecord.FileSize != remoteFile.FileSize)
                            {
                                filesToDownload.Add(remoteFile);
                                Log($"Added: {remoteFile.FileLocationAbsPath} to download queue! (update)");
                            }
                        }
                        else
                        {
                            if(localFiles.Find(x=>x.FileLocationAbsPath == remoteFile.FileLocationAbsPath) == null)
                            {
                                filesToDownload.Add(remoteFile);
                                Log($"Added: {remoteFile.FileLocationAbsPath} to download queue!");
                            }
                        }
                    }

                    foreach (var localFile in localFiles)
                    {
                        File remoteFileTableRecord = remoteFilesTable.Find(x => x.FileLocationAbsPath == localFile.FileLocationAbsPath.Replace(localDirToSync, "").Replace("\\", "/"));
                        if (remoteFileTableRecord != null)
                        {
                            if (remoteFileTableRecord.FileSize != localFile.FileSize)
                            { 
                                filesToUpload.Add(localFile);
                                Log($"Added: {localFile.FileLocationAbsPath} to upload queue! (update)");
                            }
                        }
                        else
                        {
                            if (ftpRemoteFilesList.Find(x => x.FileLocationAbsPath == localFile.FileLocationAbsPath.Replace(localDirToSync, "").Replace("\\", "/")) == null)
                            {
                                filesToUpload.Add(localFile);
                                Log($"Added: {localFile.FileLocationAbsPath} to upload queue!");
                            }
                        }
                    }
                    #endregion

                    #region ftpPart
                    foreach (var file in filesToUpload)
                    {
                        string remotePath = file.FileLocationAbsPath.Replace(localDirToSync, "").Replace("\\", "/");
                        Log($"Uploading: {file.FileLocationAbsPath}");
                        ftpManager.uploadFile(file.FileLocationAbsPath, remotePath);
                    }

                    foreach (var remoteFile in filesToDownload)
                    {
                        Log($"Downloading: {remoteFile.FileLocationAbsPath}");
                        ftpManager.downloadFile($"{localDirToSync}", remoteFile.FileLocationAbsPath);
                    }

                    foreach (var remoteFile in ftpRemoteFilesToDelete)
                    {
                        ftpManager.deleteFile(remoteFile.FileLocationAbsPath);
                    }

                    foreach (var localFile in localFilesToDelete)
                    {
                        System.IO.File.Delete($"{localDirToSync.Replace("\\", "/")}{localFile.FileLocationAbsPath}");
                    }
                    #endregion
                });

                updateRemoteFilesTable();

            }
        }
    }
}
