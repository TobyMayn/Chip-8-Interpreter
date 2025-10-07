

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

        private byte[] _registers = new byte[16];

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

        private void SetRegister(byte register, byte value)
        {
            this._registers[register] = value;
        }

        private void AddToRegister(byte register, byte value)
        {
            this._registers[register] += value;
        }

        /// <summary>
        /// Sets the value of registerA to the value of registerB
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void SetRegisterToValueOfRegister(byte registerA, byte registerB)
        {
            this._registers[registerA] = this._registers[registerB];
        }

        /// <summary>
        /// Performs an OR operation between registerA and registerB. 
        /// Then sets the registerA to the value of the operation.
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void RegisterOperationOR(byte registerA, byte registerB)
        {
            this._registers[registerA] = (byte)(this._registers[registerA] | this._registers[registerB]);
        }

        /// <summary>
        /// Performs an AND operation between registerA and registerB. 
        /// Then sets the registerA to the value of the operation.
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void RegisterOperationAND(byte registerA, byte registerB)
        {
            this._registers[registerA] = (byte)(this._registers[registerA] & this._registers[registerB]);
        }

        /// <summary>
        /// Performs a XOR operation between registerA and registerB. 
        /// Then sets the registerA to the value of the operation.
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void RegisterOperationXOR(byte registerA, byte registerB)
        {
            this._registers[registerA] = (byte)(this._registers[registerA] ^ this._registers[registerB]);
        }

        private void SetPC(ushort value)
        {
            this._pc = value;
        }

        private void GoToSubroutine(ushort memoryLocation)
        {
            this._stack.Push(this._pc);
            this.SetPC(memoryLocation);
        }

        private void ReturnFromSubroutine()
        {
            this.SetPC(this._stack.Pop());
        }
    }
}
