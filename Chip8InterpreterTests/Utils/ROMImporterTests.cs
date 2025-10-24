using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chip8Interpreter.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Interpreter.Utils.Tests
{
    [TestClass()]
    public class ROMImporterTests
    {
        [TestMethod()]
        public void ROMImporterTest()
        {
            ROMImporter rom = new ROMImporter("E:\\Programming\\Web\\VisualStudio\\Chip8\\Chip8Interpreter\\Chip8Interpreter\\ROMs\\2-ibm-logo.ch8");
            Assert.IsInstanceOfType<ROMImporter>(rom);
        }

        [TestMethod()]
        public void GetROMFileTest()
        {
            ROMImporter rom = new ROMImporter("E:\\Programming\\Web\\VisualStudio\\Chip8\\Chip8Interpreter\\Chip8Interpreter\\ROMs\\2-ibm-logo.ch8");
            byte[] bytes = rom.GetROMFile();
            byte[] expectedBytes = new byte[] 
            {
                0, 224, 162, 42, 96, 12, 97, 8, 
                208, 31, 112, 9, 162, 57, 208, 31, 
                162, 72, 112, 8, 208, 31, 112, 4, 
                162, 87, 208, 31, 112, 8, 162, 102, 
                208, 31, 112, 8, 162, 117, 208, 31, 
                18, 40, 255, 0, 255, 0, 60, 0, 
                60, 0, 60, 0, 60, 0, 255, 0, 
                255, 255, 0, 255, 0, 56, 0, 63, 
                0, 63, 0, 56, 0, 255, 0, 255, 
                128, 0, 224, 0, 224, 0, 128, 0, 
                128, 0, 224, 0, 224, 0, 128, 248, 
                0, 252, 0, 62, 0, 63, 0, 59,
                0, 57, 0, 248, 0, 248, 3, 0, 
                7, 0, 15, 0, 191, 0, 251, 0, 
                243, 0, 227, 0, 67, 229, 5, 226, 
                0, 133, 7, 129, 1, 128, 2, 128, 
                7, 225, 6, 231
            };
            CollectionAssert.AreEqual(expectedBytes, bytes);
        }
    }
}