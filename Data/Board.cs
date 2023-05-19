using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace Data
{
    internal class Board
    {
        private readonly Object locked = new();
        private List<AbstractBall> balls = new();
        private Collection<Thread> threads = new();
        private double boardHeight;
        private double boardWidth;

        public Board(int amount, double widthOfCanvas, double heightOfCanvas)
        {
            this.boardHeight = heightOfCanvas;
            this.boardWidth = widthOfCanvas;
            CreateBalls(amount);
            CreateThreads();
        }

        public void CreateBalls(int amount)
        {
            
            Random rnd = new();
            for (int i = 0; i < amount; i++)
            {
                int xposition = rnd.Next(30, (int)boardWidth - 30);
                int yposition = rnd.Next(30, (int)boardHeight - 30);
                while (!CanCreate(xposition, yposition))
                {
                    xposition = rnd.Next(30, (int)boardWidth - 30);
                    yposition = rnd.Next(30, (int)boardHeight - 30);
                }
                balls.Add(AbstractBall.CreateBall(xposition, yposition));
            }
        }

        private bool CanCreate(int x, int y)
        {
            if (balls.Count == 0) return true;
            foreach (AbstractBall b in balls)
            {
                double distance = Math.Sqrt(Math.Pow((b._xPosition - x), 2) + Math.Pow((b._yPosition - y), 2));
                if (distance <= (2 * b.Radius + 20))
                {
                    return false;
                }
            }
            return true;
        }

        private void CreateThreads()
        {
            foreach(AbstractBall b in balls)
            {
                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            Thread.Sleep(15);
                            lock (locked)
                            {
                                b.Move();
                            }
                        }
                        catch (Exception e)
                        {
                            break;
                        }

                    }
                });
                threads.Add(t);
            }
        }

        public void StartThreads()
        {
            foreach(Thread t in threads)
            {
                t.Start();
            }
        }

        public void InterruptThreads()
        {
            foreach(Thread t in threads)
            {
                t.Interrupt();
            }
        }

        public List<AbstractBall> GetBalls()
        {
            return balls;
        }

        public double GetBoardHeight()
        {
            return boardHeight;
        }

        public double GetBoardWidth()
        {
            return boardWidth;
        }

    }
}