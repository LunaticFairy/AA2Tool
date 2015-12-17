using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Artificial.Parsers.Character;

namespace ArtificialGUI
{
    public class CharacterEntry
    {
        public CharacterEntry(Character ch, BitmapSource image)
        {
            Char = ch;
            Image = image;
        }
        public Character Char { get; set; }
        public string Name { get { return Char.data.profile.firstName + " " + Char.data.profile.lastName; } }
        public BitmapSource Image { get; set; }
    }
}
