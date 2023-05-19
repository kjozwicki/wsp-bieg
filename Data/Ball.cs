using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Data
{
    class Ball : AbstractBall, INotifyPropertyChanged
    {
        public override event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public double Weight { get; set; }
        public Ball( int xP, int yP)
        {
            Random rnd = new();
            Radius = 15;
            _xPosition = xP;
            _yPosition = yP;
            Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
            Weight = 5.0;
            while (_xSpeed == 0)
            {
                _xSpeed = rnd.Next(-3, 4);
            }
            while (_ySpeed == 0)
            {
                _ySpeed = rnd.Next(-3, 4);
            }
        }
        internal override void Move()
        {
            this._xPosition += this._xSpeed;
            this._yPosition += this._ySpeed;
            OnPropertyChanged("Move");
        }
        public override void ChangeXDirection()
        {
            this._xSpeed *= -1;
        }

        public override void ChangeYDirection()
        {
            this._ySpeed *= -1;
        }
    }
}