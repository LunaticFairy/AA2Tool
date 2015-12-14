using Artificial.Parsers.PNG;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Artificial.Parsers.Character
{
    class CharacterParser
    {
        public static Character TryParse(byte[] data)
        {
            int fileSize = data.Length;
            int dataOffset = BitConverter.ToInt32(data, fileSize - 4);
            dataOffset += fileSize;
            int dataSize = 0xBC3; // always 0xBC3

            int portraitOffset = dataOffset + dataSize;

            byte[] th = data.Take(dataOffset).ToArray();
            byte[] pt = data.Skip(portraitOffset).ToArray();

            PngBitmapDecoder dth = new PngBitmapDecoder(new MemoryStream(th), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            PngBitmapDecoder dpt = new PngBitmapDecoder(new MemoryStream(pt), BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);

            BitmapSource thumb = dth.Frames[0];
            BitmapSource portrait = dpt.Frames[0];           

            Character c = new Character(thumb, portrait); // take(dataOffset) gets everything before data
            c.data = ParseData(data.Skip(dataOffset).Take(dataSize).ToArray());

            return c;
        }

        private static CharacterData ParseData(byte[] data)
        {
            CharacterData d = new CharacterData();
            // here be dragons and pain
            
            return d;
        }
    }
}