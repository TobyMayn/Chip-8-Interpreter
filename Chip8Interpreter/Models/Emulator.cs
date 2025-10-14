namespace Chip8Interpreter.Models
{
    using Chip8Interpreter.Utils;
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
            switch (instruction)
            {
                case 0x0:
                    break;
                case 0x1:
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
                    break;
                case 0x7:
                    break;
                case 0x8:
                    break;
                case 0x9:
                    break;
                case 0xA:
                    break;
                case 0xB:
                    break;
                case 0xC:
                    break;
                case 0xD:
                    break;
                case 0xE:
                    break;
                case 0xF:
                    break;
                default:
                    break;
            }
        }

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
                    var bit = (sprite & (1 << j)) != 0;

                    if (bit & this._display.Screen[x, y])
                    {
                        this._cpu.SetRegister(15, 1);
                        this._display.Screen[x, y] = false;
                    }
                    else if (bit & !this._display.Screen[x, y])
                    {
                        this._display.Screen[x, y] = true;
                    }

                    if(x== 64) { break; }
                    x++;
                }

                if(y== 32) {  break; }
                y++;
            }
        }
    }
}
