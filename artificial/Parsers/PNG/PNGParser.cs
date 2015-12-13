using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial.Parsers.PNG
{
    public class PNGParser
    {
        public static byte[] HEADER = { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
        public PNGParser(string fileName)
        {
            byte[] contents;

            if (!File.Exists(fileName))
                throw new FileNotFoundException("File [" + fileName + "] was not found.");
            contents = File.ReadAllBytes(fileName);

            if (Enumerable.SequenceEqual(contents.Take(8).ToArray(), HEADER))
                throw new PNGException("Invalid PNG header");
            contents = contents.Skip(8).ToArray();


        }
    }
}
