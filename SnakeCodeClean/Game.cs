using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeCodeClean
{
    internal class Game
    {
        public int fieldSizeX;
        public int fieldSizeY;
        public int Score { get => _score; set => _score = value; }

        private static Random random = new Random();

        private int _score = 0;
        private bool _isGameOver = false;


        public Game(int fieldSizeX, int fieldSizeY)
        {
            this.fieldSizeX = fieldSizeX;
            this.fieldSizeY = fieldSizeY;
        }
    }
}
