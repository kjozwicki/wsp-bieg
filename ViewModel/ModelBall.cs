using System;
using System.ComponentModel;
using ViewModel.ViewModel;

namespace ViewModel
{
    public class ModelBall : ViewModelBase
    {
        public double X { get; set; }

        public double Y { get; set; }
        public String Color { get; set; }

        public double Radius { get; set; }
        public ModelBall(double x, double y, double radius, String color)
        {
            this.X = x; 
            this.Y = y;
            this.Radius = radius;
            this.Color = color;
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Logic.AbstractLogicBall ball = (Logic.AbstractLogicBall)s;
            X = ball.GetX();
            Y = ball.GetY();
        }
    }
}