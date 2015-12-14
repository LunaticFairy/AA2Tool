using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Artificial.Parsers.Character
{
    public class Character
    {
        public BitmapSource thumbnail;
        public BitmapSource portrait;
        public CharacterData data;

        public Character(BitmapSource thumb, BitmapSource portrait)
        {
            thumbnail = thumb;
            this.portrait = portrait;
        }
    }
}
