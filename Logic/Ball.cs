namespace Logic
{
    public class Ball
    {
        public int _xPosition;
        public int _yPosition;
        private int _xSpeed;
        private int _ySpeed;
        private bool _moving = true;
        private const int FluentMoveTime = 8;
        public Ball(int xP, int yP, int r, int w, int xS, int yS)
        {
            _xPosition = xP;
            _yPosition = yP;
            _xSpeed = xS;
            _ySpeed = yS;
            Radius = r;
            Weight = w;
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