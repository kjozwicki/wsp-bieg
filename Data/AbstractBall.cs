using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Data;

public abstract class AbstractBall
{
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public int _xPosition;
        public int _yPosition;
        public int _xSpeed;
        public int _ySpeed;
        public int Radius;
        public string Color;
        internal abstract void Move(Stopwatch timer);
        public abstract void ChangeXDirection();
        public abstract void ChangeYDirection();
        public abstract void Update(Object o, PropertyChangedEventArgs p);

        public static AbstractBall CreateBall( int xP, int yP)
        {
                return new Ball(xP, yP);
        }
}