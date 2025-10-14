

namespace Chip8Interpreter.Models
{
    public class CPU
    {
        private const ushort START_INDEX = 0x200;
        // Setting memory to 4096 bytes
        public ushort Pc { get; set; } = START_INDEX;
        // index register called “I” which is used to point at locations in memory
        public ushort Idr { get; set; } = 0;
        private Stack<ushort> _stack = new Stack<ushort>();
        private byte _delayTimer = 60;
        private byte _soundTimer = 60;

        public byte[] Registers { get; set; } = new byte[16];

        public CPU() {
            this.ResetCPU();
        }

        /// <summary>
        /// Sets all CPU values to its initial starting values
        /// </summary>
        public void ResetCPU()
        {
            this.Pc = START_INDEX;
            this.Idr = 0;
            this._delayTimer = 60;
            this._soundTimer = 60;
            this.ClearRegisters();
        }

        public void ClearRegisters()
        {
            // Set all registers to 0 on instantiation
            for (int i = 0; i < Registers.Length - 1; i++)
            {
                this.Registers[i] = 0x0;
            }
        }

        public void SetRegister(byte register, byte value)
        {
            this.Registers[register] = value;
        }

        private void AddToRegister(byte register, byte value)
        {
            this.Registers[register] += value;
        }

        /// <summary>
        /// Sets the value of registerA to the value of registerB
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void SetRegisterToValueOfRegister(byte registerA, byte registerB)
        {
            this.Registers[registerA] = this.Registers[registerB];
        }

        /// <summary>
        /// Performs an OR operation between registerA and registerB. 
        /// Then sets the registerA to the value of the operation.
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void RegisterOperationOR(byte registerA, byte registerB)
        {
            this.Registers[registerA] = (byte)(this.Registers[registerA] | this.Registers[registerB]);
        }

        /// <summary>
        /// Performs an AND operation between registerA and registerB. 
        /// Then sets the registerA to the value of the operation.
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void RegisterOperationAND(byte registerA, byte registerB)
        {
            this.Registers[registerA] = (byte)(this.Registers[registerA] & this.Registers[registerB]);
        }

        /// <summary>
        /// Performs a XOR operation between registerA and registerB. 
        /// Then sets the registerA to the value of the operation.
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void RegisterOperationXOR(byte registerA, byte registerB)
        {
            this.Registers[registerA] = (byte)(this.Registers[registerA] ^ this.Registers[registerB]);
        }

        /// <summary>
        /// Adds the value of registerB to the value of registerB. 
        /// If overflow happens i.e the value is above 255 the flag register is set to 1, otherwise it is set to 0.
        /// </summary>
        /// <param name="registerA"></param>
        /// <param name="registerB"></param>
        private void AddRegisterToRegister(byte registerA, byte registerB)
        {
            try
            {
                this.Registers[registerA] += this.Registers[registerB];
                this.SetRegister(15, 0);
            }
            catch(OverflowException) 
            {
                this.SetRegister(15, 1);
            }
            
        }

        /// <summary>
        /// Subtracts the value of one register from another and stores the result in the first register.
        /// </summary>
        /// <remarks>The method modifies the value of the register at <paramref name="registerA"/> to
        /// store the result. Ensure that the provided register indices are valid and within the bounds of the register
        /// array.</remarks>
        /// <param name="registerA">The index of the register that will store the result of the subtraction.</param>
        /// <param name="registerB">The index of the register whose value will be subtracted.</param>
        /// <param name="orderOfSubstraction">A boolean value indicating the order of subtraction.  If <see langword="true"/>, the value of <paramref
        /// name="registerB"/> is subtracted from <paramref name="registerA"/>.  If <see langword="false"/>, the
        /// subtraction order is reversed.</param>
        private void SubtractRegisters(byte registerA, byte registerB, bool orderOfSubstraction)
        {
            this.SetRegister(15, 1);
            if (orderOfSubstraction)
            {
                this.Registers[registerA] = (byte)(this.Registers[registerA] - this.Registers[registerB]);
                if (this.Registers[registerA] < this.Registers[registerB])
                {
                    this.SetRegister(15, 0);
                }
            }
            else
            {
                this.Registers[registerA] = (byte)(this.Registers[registerB] - this.Registers[registerA]);
                if (this.Registers[registerA] > this.Registers[registerB])
                {
                    this.SetRegister(15, 0);
                }
            }
        }

        private void GoToSubroutine(ushort memoryLocation)
        {
            this._stack.Push(this.Pc);
            Pc = memoryLocation;
        }

        private void ReturnFromSubroutine()
        {
            Pc = this._stack.Pop();
        }
    }
}
