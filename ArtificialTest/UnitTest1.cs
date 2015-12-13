using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artificial.Parsers.PNG;

namespace ArtificialTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestPNG()
        {
            string file = "C:/illusion/AA2Edit/data/save/Female/cirno.png";
            PNGParser parser = new PNGParser(file);
            
        }
    }
}
