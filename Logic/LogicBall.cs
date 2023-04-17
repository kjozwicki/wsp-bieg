using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    public class LogicBall : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

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
        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Ball ball = (Ball)s; 
            X = ball._xPosition;
            Y = ball._yPosition;
            BoardLogicAbstractAPI.CreateLayer().CheckBoundariesCollision(this);
         
        }
        private readonly Ball ball;
        public LogicBall(Ball b)
        {
            ball = b;
        }
        public void ChangeXDirection()
        {
            ball.ChangeXDirection();
        }
        public void ChangeYDirection()
        {
            ball.ChangeYDirection();
        }
        public double GetX()
        {
            return X;
        }
        public double GetY()
        {
            return Y;
        }
        public double GetRadius()
        {
            return ball.Radius;
        }
    }
}