namespace Data
{
    public class BallData
    {
        private int _xPosition;
        private int _yPosition;
        private int _xSpeed;
        private int _ySpeed;
        private bool _moving = true;

        private const int FluentMoveTime = 8;

        public BallData(int xPosition, int yPosition, int radius, int weight, int xSpeed, int ySpeed)
        {
            _xPosition = xPosition;
            _yPosition = yPosition;
            _xSpeed = xSpeed;
            _ySpeed = ySpeed;
            Radius = radius;
            Weight = weight;
        }

        public int XPosition
        {
            get => _xPosition;
            internal set
            {
                _xPosition = value;
            }
        }

        public int YPosition
        {
            get => _yPosition;
            internal set
            {
                _yPosition = value;
            }
        }

        public int Weight { get; }

        public int Radius { get; }

        public int XSpeed
        {
            get => _xSpeed;
            set
            {
                _xSpeed = value;
            }
        }

        public int YSpeed
        {
            get => _ySpeed;
            set
            {
                _ySpeed = value;
            }
        }
    }
}