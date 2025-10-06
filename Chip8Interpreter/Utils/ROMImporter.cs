using System.Runtime.CompilerServices;

namespace Chip8Interpreter.Utils
{
    public class ROMImporter
    {
        private readonly byte[] _rom;

        public ROMImporter(string filePath)
        {
            this._rom = ReadROMFile(filePath);
        }

        private byte[] ReadROMFile(string filePath)
        {
            return File.ReadAllBytes(filePath);
        }

        public byte[] GetROMFile() 
        { 
            return this._rom;
        }
    }
}
