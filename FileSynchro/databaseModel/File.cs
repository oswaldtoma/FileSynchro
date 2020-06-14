using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSynchro
{ 
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public DateTime? FileLastModificationDate { get; set; }
        public string FileExtension { get; set; }
        public long FileSize { get; set; }
        public string FileLocationAbsPath { get; set; }
    }
}
