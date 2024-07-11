using SnakeCodeClean.GameElements;
using SnakeCodeClean.GUI;
using SnakeCodeClean.Tools;

namespace SnakeCodeClean
{
    internal class Game
    {
        /* Game public variables */
        public Size fieldSize;
        public int score { get => _score; set => _score = value; }
        public Snake snake { get => _snake; }
        public Berry berry { get => _berry; }
        public Boundry[] boundries { get => _boundries; }

        /* Game utilities */
        private static Random random = new Random();
        private static RenderEngine renderEngine = new RenderEngine();

        /* Game private variables */
        private int _score = 5;
        private bool _isGameOver = false;

        /* Game Objects */
        private Snake _snake = new Snake();
        private Berry _berry = new Berry();
        private Boundry[] _boundries;


        public Game(int fieldSizeX, int fieldSizeY)
        {
            // Sets information about playing field to the game
            this.fieldSize = new Size(fieldSizeX, fieldSizeY);

            // Sets starting center position for snake
            _snake.setPosition(fieldSizeX / 2, fieldSizeY / 2); 

            // Spawn berry inside game field
            _berry.spawn(fieldSize, random);

            // Creates 4 new bounderies
            _boundries = new Boundry[4];
            _boundries[0] = new Boundry(new Point(0, 0), new Size(fieldSize.width, 1));
            _boundries[1] = new Boundry(new Point(0, fieldSize.height - 1), new Size(fieldSize.width + 1, 1));
            _boundries[2] = new Boundry(new Point(0, 0), new Size(1, fieldSize.height));
            _boundries[3] = new Boundry(new Point(fieldSize.width, 0), new Size(1, fieldSize.height));
        }

        public void Run()
        {
            while (true)
            {

                // Renders actual state of the game
                RenderEngine.renderFrame(this);

                // Finishes game if snake hits boundries
                _isGameOver = this.hasGameEnded();

                if (_isGameOver)
                {
                    break;
                }

                // Player Move Variable
                Movement? playerMovement = null;

                // Time for player action
                DateTime playerActionStartTime = DateTime.Now;
                TimeSpan playerActionTimeLength = new TimeSpan(0);

                while (TimeSpan.Compare(TimeSpan.FromMilliseconds(500), playerActionTimeLength) > 0) {
                    Movement? playerAction = Controls.readPlayerInput();
                    if (playerAction != null)
                    {
                        playerMovement = playerAction;
                    }
                    playerActionTimeLength = DateTime.Now.Subtract(playerActionStartTime);
                }

                // Moves snake
                _snake.changeDirection(playerMovement);
                _snake.move(score);
                if(_snake.hasEatenBerry(_berry))
                {
                    // Spawns new berry
                    _berry.spawn(fieldSize, random);

                    // Adds to score
                    this.score++;
                }
            }

            RenderEngine.renderScore(this);
        }

        private bool hasGameEnded()
        {
            return snake.hasCollidedWith(_boundries) || snake.hasCollidedWithItself();
        }
    }
}
