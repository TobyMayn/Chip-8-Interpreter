using Microsoft.VisualStudio.TestTools.UnitTesting;
using Chip8Interpreter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chip8Interpreter.Models.Tests
{
    [TestClass()]
    public class CPUTests
    {
        [TestMethod()]
        public void CPUTest()
        {
            CPU cpu = new CPU();
            Assert.IsInstanceOfType(cpu, typeof(CPU));
        }

        [TestMethod()]
        public void ResetCPUTest()
        {
            CPU cpu = new CPU();

            cpu.Registers[2] = 8;
            cpu.Pc = 0x210;
            cpu.Idr = 0x224;

            cpu.ResetCPU();

            Assert.AreEqual(0, cpu.Registers[2]);
            Assert.AreEqual(0x200, cpu.Pc);
            Assert.AreEqual(0, cpu.Idr);

        }

        [TestMethod()]
        public void ClearRegistersTest()
        {
            CPU cpu = new CPU();

            for (int i = 0; i < cpu.Registers.Length; i++) {
                cpu.Registers[i] = (byte)(i * 2);
            }

            cpu.ClearRegisters();

            Assert.AreEqual(0, cpu.Registers[1]);

        }

        [TestMethod()]
        public void SetRegisterTest()
        {
            CPU cpu = new CPU();
            cpu.SetRegister(2, 24);

            Assert.AreEqual(24, cpu.Registers[2]);

        }

        [TestMethod()]
        public void AddToRegisterTest()
        {
            CPU cpu = new CPU();
            cpu.Registers[1] = 2;

            cpu.AddToRegister(1, 2);

            Assert.AreEqual(4, cpu.Registers[1]);

        }
    }
}