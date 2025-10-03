

namespace Chip8Interpreter.Model
{
    public class CPU
    {
        private const ushort START_INDEX = 0x200;
        // Setting memory to 4096 bytes
        private byte[] memory = new byte[0x1000];
        private ushort pc = START_INDEX;
        // index register called “I” which is used to point at locations in memory
        private ushort idr = 0;
        private Stack<ushort> stack = new Stack<ushort>();
        private byte delayTimer = 60;
        private byte soundTimer = 60;

        private int[] registers = new int[16];

        private readonly int[] fonts = new int[] {
            0xF0, 0x90, 0x90, 0x90, 0xF0, // 0
            0x20, 0x60, 0x20, 0x20, 0x70, // 1
            0xF0, 0x10, 0xF0, 0x80, 0xF0, // 2
            0xF0, 0x10, 0xF0, 0x10, 0xF0, // 3
            0x90, 0x90, 0xF0, 0x10, 0x10, // 4
            0xF0, 0x80, 0xF0, 0x10, 0xF0, // 5
            0xF0, 0x80, 0xF0, 0x90, 0xF0, // 6
            0xF0, 0x10, 0x20, 0x40, 0x40, // 7
            0xF0, 0x90, 0xF0, 0x90, 0xF0, // 8
            0xF0, 0x90, 0xF0, 0x10, 0xF0, // 9
            0xF0, 0x90, 0xF0, 0x90, 0x90, // A
            0xE0, 0x90, 0xE0, 0x90, 0xE0, // B
            0xF0, 0x80, 0x80, 0x80, 0xF0, // C
            0xE0, 0x90, 0x90, 0x90, 0xE0, // D
            0xF0, 0x80, 0xF0, 0x80, 0xF0, // E
            0xF0, 0x80, 0xF0, 0x80, 0x80  // F
        };

        public CPU() {
            this.ResetCPU();
        }

        /// <summary>
        /// Sets all CPU values to its initial starting values
        /// </summary>
        public void ResetCPU()
        {
            this.memory = new byte[0x1000];
            this.pc = START_INDEX;
            this.idr = 0;
            this.delayTimer = 60;
            this.soundTimer = 60;
            this.ClearRegisters();
            this.LoadFontsIntoMemory();
        }

        public void ClearRegisters()
        {
            // Set all registers to 0 on instantiation
            for (int i = 0; i < registers.Length - 1; i++)
            {
                this.registers[i] = 0x0;
            }
        }

        /// <summary>
        /// Loads font data into the first sections of the memory
        /// </summary>
        private void LoadFontsIntoMemory()
        {
            for (int i = 0; i < this.fonts.Length - 1; i++)
            {
                this.memory[i] = (byte)this.fonts[i];
            }
        }
    }
}
