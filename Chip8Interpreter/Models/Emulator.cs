namespace Chip8Interpreter.Models
{
    using Chip8Interpreter.Utils;
    public class Emulator
    {
        private CPU _cpu;
        private Display _display;
        private Memory _memory;
        private ROMImporter _romImporter;

        public Emulator()
        {
            _cpu = new CPU();
            _display = new Display();
            _memory = new Memory();
            _romImporter = new ROMImporter("E:\\Programming\\Web\\VisualStudio\\Chip8\\Chip8Interpreter\\Chip8Interpreter\\ROMs\\2-ibm-logo.ch8");
        }

        public void RunEmulator()
        {
         
        }

        public void LoadROMIntoMemory()
        {
        }
    }
}
