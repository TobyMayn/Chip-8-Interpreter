namespace Chip8Interpreter.Models
{
    using Chip8Interpreter.Utils;
    using System.Runtime.CompilerServices;

    public class Emulator
    {
        private CPU _cpu;
        public Display display;
        private Memory _memory;
        public bool playing = false;

        public Emulator()
        {
            ROMImporter _rom = new ROMImporter("E:\\Programming\\Web\\VisualStudio\\Chip8\\Chip8Interpreter\\Chip8Interpreter\\ROMs\\2-ibm-logo.ch8");
            _cpu = new CPU();
            display = new Display();
            _memory = new Memory();
   
            _memory.LoadROMToMemory(_rom.GetROMFile());
        }

        public void RunEmulator()
        {
            int i = 0;
            ushort instruction; 
            while (playing)
            {
                Console.WriteLine("Inside loop");
                instruction = this._memory.GetInstruction(this._cpu.Pc);
                if (instruction == 0 | instruction == 4648) {
                    i++;
                }
                this._cpu.Pc += 2;
                this.Decode(instruction);

                if (i == 4) { playing = false; }
               

            }
         
        }

        private void Decode(ushort instruction)
        {
            byte registerA, registerB, value;
            Console.WriteLine(((instruction & 0xF000)>>12).ToString("X4"));
            ushort inst = (ushort)((instruction & 0xF000)>>12);
            switch (inst)
            {
                case 0x0:
                    switch (instruction)
                    {
                        case 0x00E0:
                            Console.WriteLine("Clearing Screen");
                            this.display.ClearDisplay();
                            break;
                    }
                    break;
                case 0x1:
                    Console.WriteLine("Inside decode 1 step");
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
                    Console.WriteLine("Inside decode 6 step");
                    registerA = (byte)((instruction & 0x0F00)>>8);
                    value = (byte)(instruction & 0x00FF);
                    this._cpu.SetRegister(registerA, value);
                    break;
                case 0x7:
                    Console.WriteLine("Inside decode 7 step");
                    registerA = (byte)((instruction & 0x0F00)>>8);
                    value = (byte)(instruction & 0x00FF);
                    this._cpu.AddToRegister(registerA, value);
                    break;
                case 0x8:
                    break;
                case 0x9:
                    break;
                case 0xA:
                    Console.WriteLine("Inside decode A step");
                    this._cpu.Idr = (ushort)(instruction & 0x0FFF);
                    break;
                case 0xB:
                    break;
                case 0xC:
                    break;
                case 0xD:
                    Console.WriteLine("We are drawing something");
                    Console.WriteLine((byte)((instruction & 0x0F00)>>8));
                    registerA = (byte)((instruction & 0x0F00)>>8);
                    Console.WriteLine((byte)((instruction & 0x00F0) >> 4));
                    registerB = (byte)((instruction & 0x00F0)>>4);
                    Console.WriteLine((byte)(instruction & 0x000F));
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
            Console.WriteLine("Inside Draw loop");
            ushort x = (ushort)(this._cpu.Registers[vx] % 63);
            Console.WriteLine(x);
            ushort y = (ushort)(this._cpu.Registers[vy] % 31);
            Console.WriteLine(y);
            Console.WriteLine(n);


            this._cpu.SetRegister(15, 0);

            for (int i = 0; i < n; i++)
            {
                byte sprite = this._memory.GetByteOfMemory(this._cpu.Idr + i);
                for (int j = 0; j < 8; j++)
                {
                    // Get first bit in the sprite
                    var bit = (sprite & (1 << j)) != 0;

                    // If bit is 1 and current display bit at location x,y is true (1) flip the display pixel, i.e turn of pixel
                    if (bit & this.display.Screen[x, y])
                    {
                        this._cpu.SetRegister(15, 1);
                        this.display.Screen[x, y] = false;
                    }
                    // else turn on pixel
                    else if (bit & !this.display.Screen[x, y])
                    {
                        Console.WriteLine($"Turning on pixel ({x}, {y})");
                        this.display.Screen[x, y] = true;
                    }

                    // if we reach the right border, don't draw
                    if(x== 63) { break; }
                    x++;
                }
                // if we reach the bottom, don't draw
                if(y== 31) {  break; }
                y++;
            }
        }
    }
}
