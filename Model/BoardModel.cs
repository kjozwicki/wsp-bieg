using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class BoardModel
    {
        public BoardModel(double canvasWidth, double canvasHeight, BoardLogicAbstractAPI? boardAPI = null)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            BoardAPI = boardAPI ?? BoardLogicAbstractAPI.CreateLayer();
        }

        public ObservableCollection<AbstractLogicBall> GetStartingBallPositions(int ballCount)
        {
            Animating = true;
            return BoardAPI.CreateBalls(_canvasWidth, _canvasHeight, ballCount); ;
        }

        public void ChangeTxtYaml()
        {
            BoardAPI.ChangeTxtYaml();
        }

        public void InterruptThreads()
        {
            BoardAPI.InterruptThreads();
        }
        
        public void StartThreads()
        {
            BoardAPI.StartThreads();
        }

        private bool _animating;

        public bool Animating
        {
            get => _animating; set => _animating = value;
        }

        private readonly double _canvasWidth;

        private readonly double _canvasHeight;

        private readonly BoardLogicAbstractAPI? BoardAPI = default;
    }
}