using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class BoardLogicAbstractAPI
    {
        public static BoardLogicAbstractAPI CreateLayer(DataAbstractAPI? data = default)
        {
            return new BoardLogicAPI(data ?? DataAbstractAPI.CreateAPI());
        }

        public abstract ObservableCollection<LogicBall> CreateBalls(double boardWidth, double boardHeight, int ballCount);

        public abstract void InterruptThreads();
        
        public abstract void StartThreads();

        public abstract void CheckBoundariesCollision(LogicBall ball);

   

        private class BoardLogicAPI : BoardLogicAbstractAPI
        {
            public BoardLogicAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<LogicBall> CreateBalls(double boardWidth, double boardHeight, int ballCount)
            {
                List<Ball> balls = new();
                ObservableCollection<LogicBall> logicBalls = new();
                DataLayer.CreateBoardWithBalls(ballCount, boardWidth, boardHeight);
                height = DataLayer.GetBoardHeight();
                width = DataLayer.GetBoardWidth();
                balls = DataLayer.GetBalls();
                foreach (Ball b in balls)
                {
                    LogicBall logicBall = new LogicBall(b);
                    b.PropertyChanged += logicBall.Update!;
                    ballsCollection.Add(logicBall);
                    logicBalls.Add(logicBall);                
                }
                return logicBalls;
            }
            

            public static void UpdateBallSpeed(LogicBall ball)
            {
                if (ball.GetY() - ball.GetRadius() <= 0 || ball.GetY() + ball.GetRadius() >= height)
                {
                    ball.ChangeYDirection();
                }
                if (ball.GetX() + ball.GetRadius() >= width || ball.GetX() - ball.GetRadius() <= 0)
                {
                    ball.ChangeXDirection();
                }
            }

            private static bool checkBallBoundary(LogicBall ball)
            {
                return ball.GetY() - ball.GetRadius() <= 0 || ball.GetX() + ball.GetRadius() >= width || ball.GetY() + ball.GetRadius() >= height || ball.GetX() - ball.GetRadius() <= 0 ? false : true;
            }

            public override void CheckBoundariesCollision(LogicBall ball)
            {
                UpdateBallSpeed(ball);
            }

 

            public override void InterruptThreads()
            {
                DataLayer.InterruptThreads();
                ballsCollection.Clear();
            }
            
            public override void StartThreads()
            {
                DataLayer.StartThreads();
            }

            private readonly DataAbstractAPI DataLayer;
            private static Collection<LogicBall> ballsCollection = new();
            private static double height;
            private static double width;
        }
    }
}