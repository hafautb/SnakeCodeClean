using SnakeCodeClean.Tools;

namespace SnakeCodeClean.GameElements
{
    internal class Snake
    {
        public Movement direction { get => _direction; }
        public Point headPosition { get => _headPosition; }
        public List<Point> bodyPosition { get => _bodyPosition; }

        private Movement _direction = Movement.Right;
        private Point _headPosition;
        private List<Point> _bodyPosition;

        public Snake()
        {
            _headPosition = new Point (0, 0);
            _bodyPosition = new List<Point>();
        }

        public void changeDirection(Movement? direction)
        {
            if (direction == null) return;

            // Checks for movement, where body is 
            if ((direction == Movement.Left && _direction == Movement.Right) ||
                (direction == Movement.Right && _direction == Movement.Left) ||
                (direction == Movement.Up && _direction == Movement.Down) ||
                (direction == Movement.Down && _direction == Movement.Up))
            {
                return;
            }

            // Changes the direction
            _direction = (Movement) direction;            
        }

        public void setPosition(int x, int y)
        {
            _headPosition = new Point(x, y);
        }

        public void move(int score)
        {
            Point moveVector;

            // Selects direction vector to move
            switch(_direction)
            {
                case Movement.Left:
                    moveVector = new Point(-1, 0);
                    break;
                case Movement.Right:
                    moveVector = new Point(1, 0);
                    break;
                case Movement.Up:
                    moveVector = new Point(0, -1);
                    break;
                case Movement.Down:
                    moveVector = new Point(0, 1);
                    break;
                default:
                    moveVector = new Point(0, 0); 
                    break;
            }

            // Grows missing body parts or moves last body part to head position
            if (score - 1 > _bodyPosition.Count) { 
                _bodyPosition.Insert(0, _headPosition);
            }
            else
            {
                _bodyPosition.Insert(0, new Point(_headPosition.x, _headPosition.y));
                _bodyPosition.Remove(_bodyPosition.Last<Point>());
            }


            // Moves head to position
            _headPosition += moveVector;
        }

        public bool hasEatenBerry(Berry berry)
        {
            return berry.position == _headPosition;
        }

        public bool hasCollidedWith(Boundry[] boundries)
        {
            foreach (Boundry boundry in boundries)
            {
                Point boundryEndpoint = boundry.getEndPoint();
                if((headPosition.x >= boundry.startPoint.x && headPosition.x <= boundryEndpoint.x) &&
                    (headPosition.y >= boundry.startPoint.y && headPosition.y <= boundryEndpoint.y))
                {
                    return true;
                }
            }

            return false;
        }

        public bool hasCollidedWithItself()
        {
            foreach (Point bodyPart in bodyPosition)
            {
                if(bodyPart == headPosition)
                {
                    return true;
                }
            }

            return false;
        }
    }

    public enum Movement
    {
        Up,
        Down,
        Left,
        Right
    }
}
