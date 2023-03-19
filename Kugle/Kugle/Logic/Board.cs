using Data;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class Board
    {
        private double boardWidth;
        private double boardHeight;
        public Board(double bW, double bH)
        {
            boardWidth = bW;
            boardHeight = bH;
        }
        public abstract ObservableCollection<BallData> CreateBalls(int ballCount);
        public abstract ObservableCollection<BallData> UpdateBallsPosition(ObservableCollection<BallData> balls);

        private class BoardAPI : Board
        {
            public BoardAPI(double bW, double bH) : base(bW, bH)
            {
            }
            public override ObservableCollection<BallData> CreateBalls(int ballCount)
            {
                ObservableCollection<BallData> balls = new();
                for (int i = 0; i < ballCount; i++)
                {
                    BallData circle = new((int)boardWidth - 20, (int)boardHeight - 20, 1, 1, 1, 1);
                    balls.Add(circle);
                }
                return balls;
            }

            public override ObservableCollection<BallData> UpdateBallsPosition(ObservableCollection<BallData> balls)
            {
                ObservableCollection<BallData> newBalls = new();
                for(int i = 0; i < balls.Count; i++)
                {
                    if (balls[i]._xPosition + balls[i].Radius + 1 > boardWidth || balls[i]._xPosition - balls[i].Radius - 1 < 0) balls[i].XSpeed *= -1;
                    if (balls[i]._yPosition + balls[i].Radius + 1 > boardHeight || balls[i]._yPosition - balls[i].Radius - 1 < 0) balls[i].YSpeed *= -1;
                    balls[i]._xPosition += balls[i].XSpeed;
                    balls[i]._yPosition += balls[i].YSpeed;
                    newBalls.Add(balls[i]);
                }
                return newBalls;
            }
        }
    }
}