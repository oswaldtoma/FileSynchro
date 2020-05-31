using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{
    static public class Synchronization
    {
        static public FileSynchroDbContext fileSynchroDb = new FileSynchroDbContext();

        static public string getSHA1Checksum(FileInfo file)
        {
            using (FileStream fs = file.OpenRead())
            {
                SHA1 sha = new SHA1Managed();
                return BitConverter.ToString(sha.ComputeHash(fs));
            }
        }

        static public List<File> localFiles = new List<File>();
        static public void init()
        {
            fileSynchroDb.Database.CreateIfNotExists();
            DirectoryInfo directory = new DirectoryInfo(".");
            FileInfo[] files = directory.GetFiles();

            foreach (var file in files)
            {
                File tempFile = new File
                {
                    FileName = file.Name,
                    SHA1Checksum = getSHA1Checksum(file),
                    FileCreationDate = file.CreationTime,
                    FileLastModificationDate = file.LastWriteTime,
                    FilePlacementDate = null,
                    FileType = file.Extension,
                    FileSize = file.Length,
                    FileLocation = file.Name
                };
                localFiles.Add(tempFile);
            }
        }
    }
}
