using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    public class Ball
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
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
        public Ball( int xP, int yP)
        {
            Random rnd = new();
            Radius = 15;
            _xPosition = xP;
            _yPosition = yP;
            Weight = 5;
            while (XSpeed == 0)
            {
                XSpeed = rnd.Next(-3, 4);
            }
            while (YSpeed == 0)
            {
                YSpeed = rnd.Next(-3, 4);
            }
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
        public void Move()
        {
            this._xPosition += this.XSpeed;
            this._yPosition += this.YSpeed;
            OnPropertyChanged("Move");
        }
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
        public void ChangeXDirection()
        {
            this._xSpeed *= -1;
        }

        public void ChangeYDirection()
        {
            this._ySpeed *= -1;
        }
    }
}