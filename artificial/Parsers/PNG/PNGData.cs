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
            sections = new List<PNGSection>();
        }

        public List<PNGSection> GetSections()
        {
            return sections;
        }

        public void AddSection(PNGSection sect)
        {
            sections.Add(sect);
        }

        public byte[] SerializeData()
        {
            List<byte> data = new List<Byte>();
            data.AddRange(PNGParser.HEADER);

            foreach(PNGSection item in sections)
            {

                byte[] crc = BitConverter.GetBytes(item.CRC32).Reverse().ToArray();
                byte[] length = BitConverter.GetBytes(item.Data.Length).Reverse().ToArray();
                byte[] section = Encoding.ASCII.GetBytes(item.Name).ToArray();

                data.AddRange(length);
                data.AddRange(section);
                data.AddRange(item.Data);
                data.AddRange(crc);
            }
            return data.ToArray();
        }

        private List<PNGSection> sections;
    }
}
