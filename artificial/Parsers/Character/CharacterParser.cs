using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Artificial.Parsers.Character
{
    public class CharacterParser
    {
        public static Character TryRead(Stream s)
        {
            PngBitmapDecoder dth = new PngBitmapDecoder(s, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);
            CharacterData dat = ReadCharacterData(s);
            PngBitmapDecoder dpt = new PngBitmapDecoder(s, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.Default);

            BitmapSource thumb = dth.Frames[0];
            BitmapSource portrait = dpt.Frames[0];

            Character c = new Character(thumb, portrait);
            c.data = dat;

            return c;
        }

        private static CharacterData ReadCharacterData(Stream s)
        {
            CharacterData d = new CharacterData();
            // here be dragons and pain
            
            return d;
        }
    }
}