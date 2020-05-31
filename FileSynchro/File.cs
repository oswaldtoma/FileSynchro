using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FileSync
{ 
    public class File
    {
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string SHA1Checksum { get; set; }
        public DateTime? FileCreationDate { get; set; }
        public DateTime? FileLastModificationDate { get; set; }
        public DateTime? FilePlacementDate { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string FileLocation { get; set; }
    }
}
