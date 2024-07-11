using System;
using SnakeCodeClean.GameElements;

namespace SnakeCodeClean.GUI
{
    internal class Controls
    {
        public static Movement? readPlayerInput()
        {
            if(Console.KeyAvailable)
            {
                ConsoleKeyInfo pressed = Console.ReadKey(true);

                switch (pressed.Key) {
                    case ConsoleKey.UpArrow:
                        return Movement.Up;
                    case ConsoleKey.DownArrow:
                        return Movement.Down;
                    case ConsoleKey.LeftArrow:
                        return Movement.Left;
                    case ConsoleKey.RightArrow:
                        return Movement.Right;
                    default:
                        return null;
                }
            }
            else return null;
        }
    }
}
