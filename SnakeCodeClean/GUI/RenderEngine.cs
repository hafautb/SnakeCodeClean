using SnakeCodeClean.GameElements;
using SnakeCodeClean.GUI;
using SnakeCodeClean.Tools;

namespace SnakeCodeClean.GUI
{
    internal class RenderEngine
    {
        public static void renderFrame(Game currentGame)
        {
            Console.Clear();

            renderBounderies(currentGame.boundries);

            renderSnake(currentGame.snake);

            renderBerry(currentGame.berry);
        }

        public static void renderScore(Game currentGame)
        {
            Console.SetCursorPosition(currentGame.fieldSize.width / 5, currentGame.fieldSize.height / 2);
            Console.WriteLine($"Game over, Score: {currentGame.score}");
            Console.SetCursorPosition(currentGame.fieldSize.width / 5, currentGame.fieldSize.height / 2 + 1);
        }

        private static void renderSnake(Snake snake)
        {
            // Render body
            foreach (Point bodyPoint in snake.bodyPosition)
            {
                Console.SetCursorPosition(bodyPoint.x, bodyPoint.y);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("■");
            }

            // Render head
            Console.SetCursorPosition(snake.headPosition.x, snake.headPosition.y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("■");
        }

        private static void renderBounderies(Boundry[] boundries)
        {
            // Render each boundry
            foreach(Boundry boundry in boundries)
            {
                Point boundryEndPoint = boundry.getEndPoint();
                Console.ForegroundColor = ConsoleColor.Gray;

                for (int y = boundry.startPoint.y; y <= boundryEndPoint.y; y++)
                {
                    Console.SetCursorPosition(boundry.startPoint.x, y);
                    for (int x = boundry.startPoint.x; x <= boundryEndPoint.x; x++)
                    {
                        Console.Write("■");
                    }
                }
            }
        }

        private static void renderBerry(Berry berry)
        {
            // Rendry berry
            Console.SetCursorPosition(berry.position.x, berry.position.y);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("■");
        }
    }
}
