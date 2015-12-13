using Artificial.Parsers.PNG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial.Parsers.Character
{
    class Character
    {
        public PNGData thumbnail;
        public PNGData portrait;
        public CharacterData data;

        public Character(PNGData thumb, PNGData portrait)
        {
            thumbnail = thumb;
            this.portrait = portrait;
        }
    }
}
