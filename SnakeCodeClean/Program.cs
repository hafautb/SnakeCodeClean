using SnakeCodeClean.GUI;

namespace SnakeCodeClean
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Sets console window size
            // Note: only works in Windows 10 or lower
            // Console.SetWindowSize(33, 17);

            Game gameInstance = new Game(32, 16);
            gameInstance.Run();
        }
    }
}
