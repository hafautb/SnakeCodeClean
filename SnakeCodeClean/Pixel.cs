using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeCodeClean
{
    internal class Pixel
    {
        public int X;
        public int Y;
        public ConsoleColor Color;

        public Pixel(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
