using SnakeCodeClean.Tools;

namespace SnakeCodeClean.GameElements
{
    internal class Berry
    {
        public Point position;

        public void spawn(Size field, Random generator)
        {
            position = new Point(generator.Next(0 + 1, field.width - 1), generator.Next(0 + 1, field.height - 1));
        }

    }
}
