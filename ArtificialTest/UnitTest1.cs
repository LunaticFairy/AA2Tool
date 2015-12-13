using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artificial.Parsers.PNG;
using System.IO;

namespace ArtificialTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPNG()
        {
            string file = "C:/illusion/AA2Edit/data/save/Female/cirno.png";
            PNGData data = PNGParser.TryParse(File.ReadAllBytes(file));
            
        }
    }
}
