namespace Chip8Interpreter.Models
{
    using Chip8Interpreter.Utils;
    using System.Runtime.CompilerServices;

    public class Emulator
    {
        private CPU _cpu;
        private Display _display;
        private Memory _memory;
        public bool playing = false;

        public Emulator()
        {
            _cpu = new CPU();
            _display = new Display();
            _memory = new Memory();
            new ROMImporter("E:\\Programming\\Web\\VisualStudio\\Chip8\\Chip8Interpreter\\Chip8Interpreter\\ROMs\\2-ibm-logo.ch8");
        }

        public void RunEmulator()
        {
            ushort instruction; 
            while (playing)
            {
                instruction = this._memory.GetInstruction(this._cpu.Pc);
                this._cpu.Pc += 2;
                this.Decode(instruction);
            }
         
        }

        private void Decode(ushort instruction)
        {
            byte registerA, registerB, value;
            switch (instruction & 0xF000)
            {
                case 0x0:
                    switch (instruction)
                    {
                        case 0x00E0:
                            this._display.ClearDisplay();
                            break;
                    }
                    break;
                case 0x1:
                    this._cpu.Pc = (ushort)(instruction & 0x0FFF);
                    break;
                case 0x2:
                    break;
                case 0x3:
                    break;
                case 0x4:
                    break;
                case 0x5:
                    break;
                case 0x6:
                    registerA = (byte)(instruction & 0x0F00);
                    value = (byte)(instruction & 0x00FF);
                    this._cpu.SetRegister(registerA, value);
                    break;
                case 0x7:
                    registerA = (byte)(instruction & 0x0F00);
                    value = (byte)(instruction & 0x00FF);
                    this._cpu.AddToRegister(registerA, value);
                    break;
                case 0x8:
                    break;
                case 0x9:
                    break;
                case 0xA:
                    this._cpu.Idr = (ushort)(instruction & 0x0FFF);
                    break;
                case 0xB:
                    break;
                case 0xC:
                    break;
                case 0xD:
                    registerA = (byte)(instruction & 0x0F00);
                    registerB = (byte)(instruction & 0x00F0);
                    value = (byte)(instruction & 0x000F);
                    Draw(registerA, registerB, value);
                    break;
                case 0xE:
                    break;
                case 0xF:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Draw to screen. Gets x and y position of the sprite from the values stored in the two registers (vx, vy).
        /// Will draw an N tall sprite, starting at the x and y position.
        /// </summary>
        /// <param name="vx"></param>
        /// <param name="vy"></param>
        /// <param name="n"></param>
        public void Draw(ushort vx, ushort vy, ushort n)
        {
            ushort x = (ushort)(this._cpu.Registers[vx] % 64);
            ushort y = (ushort)(this._cpu.Registers[vy] % 32);

            this._cpu.SetRegister(15, 0);

            for (int i = 0; i < n; i++)
            {
                byte sprite = this._memory.GetByteOfMemory(this._cpu.Idr + i);
                for (int j = 0; j < 8; j++)
                {
                    // Get first bit in the sprite
                    var bit = (sprite & (1 << j)) != 0;

                    // If bit is 1 and current display bit at location x,y is true (1) flip the display pixel, i.e turn of pixel
                    if (bit & this._display.Screen[x, y])
                    {
                        this._cpu.SetRegister(15, 1);
                        this._display.Screen[x, y] = false;
                    }
                    // else turn on pixel
                    else if (bit & !this._display.Screen[x, y])
                    {
                        this._display.Screen[x, y] = true;
                    }

                    // if we reach the right border, don't draw
                    if(x== 64) { break; }
                    x++;
                }
                // if we reach the bottom, don't draw
                if(y== 32) {  break; }
                y++;
            }
        }
    }
}
