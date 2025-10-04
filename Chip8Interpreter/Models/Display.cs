namespace Chip8Interpreter.Models
{
    public class Display
    {
        public const int SCREEN_WIDTH = 64;
        public const int SCREEN_HEIGHT = 32;
        private bool[,] _display = new bool[SCREEN_WIDTH, SCREEN_HEIGHT];

        public void ClearDisplay() => this._display = new bool[SCREEN_WIDTH, SCREEN_HEIGHT];
    }
}
