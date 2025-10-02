

namespace Chip8Interpreter.Model
{
    public class CPU
    {
        private const ushort _START_INDEX = 0x200;
        private readonly byte[] _memory = new byte[0x1000];
        private ushort _pc = _START_INDEX;
        // index register called “I” which is used to point at locations in memory
        private ushort _i = 0;
        private ushort[] _stack = new ushort[16];
        private byte _delayTimer = 60;
        private byte _soundTimer = 60;

        public const int SCREEN_WIDTH = 64;
        public const int SCREEN_HEIGHT = 32;
        private bool[,] _display = new bool[SCREEN_WIDTH, SCREEN_HEIGHT];

        private int[] registers = new int[16];

        public CPU() {
            for (int i = 0; i < registers.Length-1; i++)
            {
                registers[i] = 0;
            }        
        }
    }
}
