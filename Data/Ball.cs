using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
        public bool TxtYaml { get; set; }
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
        internal override void Move(Stopwatch timer)
        {
            int mul = (int)timer.ElapsedMilliseconds / 1000;
            this._xPosition += this._xSpeed + mul;
            this._yPosition += this._ySpeed + mul;
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

        public override void ChangeTxtYaml()
        {
            if (TxtYaml) TxtYaml = false;
            else TxtYaml = true;
        }

        public override void Update(Object o, PropertyChangedEventArgs p)
        {
            if (TxtYaml) Logger.GetInstance().SaveDateAsTxt(_xPosition, _yPosition, _xSpeed, _ySpeed, this.GetHashCode());
            else Logger.GetInstance().SaveDateAsYaml(_xPosition, _yPosition, _xSpeed, _ySpeed, this.GetHashCode());
        }
    }
}