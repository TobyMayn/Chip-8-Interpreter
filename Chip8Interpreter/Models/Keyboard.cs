namespace Chip8Interpreter.Model
{
    public class Keyboard
    {
        private readonly string[,] layout = new string[4, 4] {
            {"1", "2", "3", "C"},
            {"4", "5", "6", "D"},
            {"7", "8", "9", "E"},
            {"A", "0", "B", "F"}
        };
    }
}
