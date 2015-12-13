using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial.Parsers.PNG
{
    public class PNGSection
    {
        public PNGSection(string name, byte[] data)
        {
            Name = name;
            Data = data;
        }

        public string Name { get; set; }
        public byte[] Data { get; set; }
        public int Length { get { return Data.Length; } }
        public uint CRC32
        {
            get
            {
                return CRC.Crc32(Data, 0, Data.Length, CRC.Crc32Section(Name));
            }
        }
    }
}
