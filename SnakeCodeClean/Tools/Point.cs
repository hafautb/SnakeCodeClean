﻿namespace SnakeCodeClean.Tools
{
    internal class Point
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point a, Point b) => new Point(a.x + b.x, a.y + b.y);
        public static Point operator -(Point a, Point b) => new Point(a.x - b.x, a.y - b.y);

        public static bool operator ==(Point a, Point b) => (a.x == b.x && a.y == b.y);
        public static bool operator !=(Point a, Point b) => ((a.x != b.x) || (a.y != b.y));
    }
}
