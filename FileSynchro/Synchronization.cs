using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
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
        static public FileSynchroDbContext fileSynchroDb = new FileSynchroDbContext();
        static List<File> localFiles = new List<File>();
        static string localDirToSync = "";

        static public string getSHA1Checksum(FileInfo file)
        {
            using (FileStream fs = file.OpenRead())
            {
                SHA1 sha = new SHA1Managed();
                return BitConverter.ToString(sha.ComputeHash(fs));
            }
        }


        static public void init(string localDirPath)
        {
            localDirToSync = localDirPath;
            fileSynchroDb.Database.CreateIfNotExists();
        }

        static void scanLocalFiles()
        {
            DirectoryInfo directory = new DirectoryInfo(localDirToSync);
            FileInfo[] files = directory.GetFiles();

            foreach (var file in files)
            {
                File tempFile = new File
                {
                    FileName = file.Name,
                    SHA1Checksum = getSHA1Checksum(file),
                    FileCreationDate = file.CreationTime,
                    FileLastModificationDate = file.LastWriteTime,
                    FileUploadDate = null,
                    FileExtension = file.Extension,
                    FileSize = file.Length,
                    FileLocation = file.Name
                };
                localFiles.Add(tempFile);
            }
        }

        static void updateRemoteFilesTable()
        {

        }

        static void compareFiles()
        {
            //fileSynchroDb.
        }
    }
}
