namespace Chip8Interpreter.Models
{
    public class Display
    {
        public const ushort SCREEN_WIDTH = 64;
        public const ushort SCREEN_HEIGHT = 32;
        public bool[,] Screen { get; set; } = new bool[SCREEN_WIDTH, SCREEN_HEIGHT];

        public void ClearDisplay() => this.Screen = new bool[SCREEN_WIDTH, SCREEN_HEIGHT];
    }
}
