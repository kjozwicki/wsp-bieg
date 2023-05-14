using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

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
        public string Color { get; set; }
        public double Weight { get; set; }
        public Ball( int xP, int yP)
        {
            Random rnd = new();
            Radius = 15;
            _xPosition = xP;
            _yPosition = yP;
            Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
            Weight = 5.0;
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