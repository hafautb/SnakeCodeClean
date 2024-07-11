using SnakeCodeClean.Tools;

namespace SnakeCodeClean.GameElements
{
    internal class Boundry
    {
        public Point startPoint;
        public Size size;

        public Boundry(Point startPoint, Size size)
        {
            this.startPoint = startPoint;
            this.size = size;
        }

        public Point getEndPoint()
        {
            return new Point(startPoint.x + size.width - 1, startPoint.y + size.height - 1);
        }
    }
}
