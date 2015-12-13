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

        public PNGSection(string name)
        {
            Name = name;
            Data = null;
        }

        public string Name { get; set; }
        public byte[] Data { get; set; }
        public int Length { get { return Data.Length; } }
        public byte[] Raw
        {
            get
            {
                // What an incredible failure for a language. SMH – manthrax @ stackoverflow
                byte[] name = Encoding.ASCII.GetBytes(Name);
                byte[] crc = BitConverter.GetBytes(CRC32).Reverse().ToArray();
                List<byte> r = name.ToList();
                r.AddRange(crc.ToList());
                return r.ToArray();
            }
        }
        public uint CRC32
        {
            get
            {
                if (Data != null)
                    return CRC.Crc32(Data, 0, Data.Length, CRC.Crc32Section(Name));
                return CRC.Crc32Section(Name);
            }
        }
    }
}
