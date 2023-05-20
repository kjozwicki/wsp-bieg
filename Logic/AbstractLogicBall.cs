using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Data;

namespace Logic
{
    public abstract class AbstractLogicBall
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public abstract void Update(Object s, PropertyChangedEventArgs e);
        public abstract void ChangeXDirection();
        public abstract void ChangeYDirection();
        public abstract double GetX();
        public abstract double GetY();
        public abstract double GetRadius();
        public abstract String GetColor();
        public abstract void ChangeTxtYaml();
        public static AbstractLogicBall CreateBall(AbstractBall b)
        {
            return new LogicBall(b);
        }
    }
}