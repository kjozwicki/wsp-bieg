using System;
using System.ComponentModel;
using ViewModel.ViewModel;

namespace ViewModel
{
    public class ModelBall : ViewModelBase
    {
        public double X { get; set; }

        public double Y { get; set; }

        public double Radius { get; set; }
        public ModelBall(double x, double y, double radius)
        {
            this.X = x; 
            this.Y = y;
            this.Radius = radius;
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Logic.LogicBall ball = (Logic.LogicBall)s;
            X = ball.X;
            Y = ball.Y;
        }
    }
}