using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artificial.Parsers.PNG
{
    public class PNGException : Exception
    {
        public PNGException(string message) : base(message)
        { }
    }
}
