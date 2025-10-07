

namespace Chip8Interpreter.Models
{
    public class CPU
    {
        private const ushort START_INDEX = 0x200;
        // Setting memory to 4096 bytes
        private ushort _pc = START_INDEX;
        // index register called “I” which is used to point at locations in memory
        private ushort _idr = 0;
        private Stack<ushort> _stack = new Stack<ushort>();
        private byte _delayTimer = 60;
        private byte _soundTimer = 60;

        private int[] _registers = new int[16];

        public CPU() {
            this.ResetCPU();
        }

        /// <summary>
        /// Sets all CPU values to its initial starting values
        /// </summary>
        public void ResetCPU()
        {
            this._pc = START_INDEX;
            this._idr = 0;
            this._delayTimer = 60;
            this._soundTimer = 60;
            this.ClearRegisters();
        }

        public void ClearRegisters()
        {
            // Set all registers to 0 on instantiation
            for (int i = 0; i < _registers.Length - 1; i++)
            {
                this._registers[i] = 0x0;
            }
        }
    }
}
