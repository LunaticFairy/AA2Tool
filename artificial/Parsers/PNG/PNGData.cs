using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial.Parsers.PNG
{
    public class PNGData
    {
        public PNGData()
        {
            sections = new Dictionary<string, byte[]>();
        }

        public byte[] GetSection(string name)
        {
            byte[] value;
            sections.TryGetValue(name, out value);
            return value;
        }

        public void SetSection(string name, byte[] value)
        {
            sections.Add(name, value);
        }

        public byte[] SerializeData()
        {
            List<byte> data = new List<Byte>();
            data.AddRange(PNGParser.HEADER);

            foreach(KeyValuePair<string, byte[]> item in sections)
            {
                uint crcSection = CRC.Crc32Section(item.Key);
                uint crcVal = CRC.Crc32(item.Value, 0, item.Value.Length, crcSection);
                byte[] crc = BitConverter.GetBytes(crcVal).Reverse().ToArray();
                byte[] length = BitConverter.GetBytes(item.Value.Length).Reverse().ToArray();
                byte[] section = Encoding.ASCII.GetBytes(item.Key).Reverse().ToArray();

                data.AddRange(length);
                data.AddRange(section);
                data.AddRange(item.Value);
                data.AddRange(crc);
            }
            return data.ToArray();
        }

        private Dictionary<string, byte[]> sections;
    }
}
