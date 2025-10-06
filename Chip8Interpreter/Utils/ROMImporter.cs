using System.Runtime.CompilerServices;

namespace Chip8Interpreter.Utils
{
    public class ROMImporter
    {
        private readonly byte[] _rom;

        public ROMImporter(string filePath)
        {
            try
            {
                this._rom = ReadROMFile(filePath);
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException(e.Message);
            }
            
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
