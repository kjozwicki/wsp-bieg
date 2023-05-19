using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    internal class LogicBall : AbstractLogicBall, INotifyPropertyChanged
    {
        public override event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double _x;
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }
        private double _y;
        public double Y 
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }
        public override void Update(Object s, PropertyChangedEventArgs e)
        {
            AbstractBall ball = (AbstractBall)s; 
            X = ball._xPosition;
            Y = ball._yPosition;
            BoardLogicAbstractAPI.CreateLayer().CheckBoundariesCollision(this);
            BoardLogicAbstractAPI.CreateLayer().CheckCollisionsWithBalls(this);
        }
        private readonly AbstractBall ball;
        public LogicBall(AbstractBall b)
        {
            ball = b;
        }
        public override void ChangeXDirection()
        {
            ball.ChangeXDirection();
        }
        public override void ChangeYDirection()
        {
            ball.ChangeYDirection();
        }
        public override double GetX()
        {
            return X;
        }
        public override double GetY()
        {
            return Y;
        }
        public override double GetRadius()
        {
            return ball.Radius;
        }

        public override String GetColor()
        {
            return ball.Color;
        }
    }
}