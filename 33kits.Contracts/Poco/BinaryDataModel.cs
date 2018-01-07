using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _33kits.Contracts.Poco
{
    public class BinaryDataModel
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public Stream Stream { get; set; }
    }
}
