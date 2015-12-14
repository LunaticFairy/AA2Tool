using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Artificial.Parsers.Character;
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
            FileStream s = File.Open(file, FileMode.Open);
            Character c = CharacterParser.TryRead(s);
            
        }
    }
}
