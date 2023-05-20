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

        public abstract ObservableCollection<AbstractLogicBall> CreateBalls(double boardWidth, double boardHeight, int ballCount);
        public abstract void ChangeTxtYaml();
        public abstract void InterruptThreads();
        
        public abstract void StartThreads();

        public abstract void CheckBoundariesCollision(AbstractLogicBall ball);
        public abstract void CheckCollisionsWithBalls(AbstractLogicBall ball);

   

        private class BoardLogicAPI : BoardLogicAbstractAPI
        {
            public BoardLogicAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<AbstractLogicBall> CreateBalls(double boardWidth, double boardHeight, int ballCount)
            {
                List<AbstractBall> balls = new();
                ObservableCollection<AbstractLogicBall> logicBalls = new();
                DataLayer.CreateBoardWithBalls(ballCount, boardWidth, boardHeight);
                height = DataLayer.GetBoardHeight();
                width = DataLayer.GetBoardWidth();
                balls = DataLayer.GetBalls();
                foreach (AbstractBall b in balls)
                {
                    AbstractLogicBall logicBall = AbstractLogicBall.CreateBall(b);
                    b.PropertyChanged += logicBall.Update!;
                    ballsCollection.Add(logicBall);
                    logicBalls.Add(logicBall);                
                }
                return logicBalls;
            }
            
            private static bool BallsCollission(AbstractLogicBall ball)
            {
                foreach (AbstractLogicBall b in ballsCollection)
                {
                    double distance = Math.Ceiling(Math.Sqrt(Math.Pow((b.GetX() - ball.GetX()), 2) + Math.Pow((b.GetY() - ball.GetY()), 2)));
                    if (b != ball && distance <= (b.GetRadius() + ball.GetRadius()) && checkBallBoundary(ball))
                    {
                        ball.ChangeXDirection();
                        ball.ChangeYDirection();
                        return true;
                    }
                }
                return false;
            }
            
            public static void UpdateBallSpeed(AbstractLogicBall ball)
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

            private static bool checkBallBoundary(AbstractLogicBall ball)
            {
                return ball.GetY() - ball.GetRadius() <= 0 || ball.GetX() + ball.GetRadius() >= width || ball.GetY() + ball.GetRadius() >= height || ball.GetX() - ball.GetRadius() <= 0 ? false : true;
            }

            public override void CheckBoundariesCollision(AbstractLogicBall ball)
            {
                UpdateBallSpeed(ball);
            }

            public override void CheckCollisionsWithBalls(AbstractLogicBall ball)
            {
                BallsCollission(ball);
            }

            public override void ChangeTxtYaml()
            {
                foreach (AbstractLogicBall b in ballsCollection)
                {
                    b.ChangeTxtYaml();
                }
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
            private static Collection<AbstractLogicBall> ballsCollection = new();
            private static double height;
            private static double width;
        }
    }
}