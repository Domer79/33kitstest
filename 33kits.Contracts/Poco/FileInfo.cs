using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33kits.Contracts.Poco
{
    public class FileInfo
    {
        public Guid Id { get; set; }
        public string Hash { get; set; }
        public string FileName { get; set; }
    }
}
