using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace Chip8Interpreter.Models
{
    public class Memory
    {
        private const ushort START_INDEX = 0x200;
        public byte[] memory { get; }

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

        public Memory() 
        { 
            memory = new byte[0x1000];
            this.LoadFontsIntoMemory();
        }


        public void LoadROMToMemory(byte[] rom)
        {
            for (int i = 0; i < rom.Length; i++)
            {
                this.memory[i+START_INDEX] = rom[i];
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

        public byte GetByteOfMemory(int index)
        {
            return this.memory[index];
        }

        public ushort GetInstruction(int index)
        {
            Console.WriteLine((ushort)((this.memory[index] << 8) | this.memory[index + 1]));
            return (ushort)((this.memory[index] << 8) | this.memory[index + 1]);
        }
    }
}
