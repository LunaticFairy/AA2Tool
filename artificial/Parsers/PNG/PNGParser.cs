using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial.Parsers.PNG
{
    public class PNGParser
    {
        public static byte[] HEADER = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

        byte[] contents;

        public PNGParser(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("File [" + fileName + "] was not found.");
            contents = File.ReadAllBytes(fileName);

            if (!Enumerable.SequenceEqual(contents.Take(8).ToArray(), HEADER))
                throw new PNGException("Invalid PNG header");

            contents = contents.Skip(8).ToArray();
        }

        public PNGData TryParse()
        {

            PNGData pngdata = new PNGData();
            int offset = 0;

            while (true)
            {
                try
                {
                    int length = BitConverter.ToInt32(contents.Skip(offset).Take(4).Reverse().ToArray(), 0);
                    string name = Encoding.ASCII.GetString(contents.Skip(offset + 4).Take(4).ToArray());
                    byte[] data = contents.Skip(offset + 8).Take(length).ToArray();

                    if (name == "IEND")
                        break;

                    pngdata.AddSection(new PNGSection(name, data));
                    offset = offset + length + 12;
                }
                catch (Exception)
                {
                    break;
                }
            }
            return pngdata;
        }
    }
}
