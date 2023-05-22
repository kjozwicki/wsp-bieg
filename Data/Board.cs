using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace Data
{
    internal class Board
    {
        private readonly Object locked = new();
        private readonly Object lockedToSave = new();
        private List<AbstractBall> balls = new();
        private Collection<Thread> threads = new();
        private Collection<Thread> threadsToSave = new();
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
                    DateTime start = DateTime.UtcNow;
                    DateTime end = DateTime.UtcNow;
                    while (true)
                    {
                        try
                        {
                            lock (locked)
                            {
                                TimeSpan timeDiff = end - start;
                                b.Move(timeDiff.TotalMilliseconds);
                            }
                            Thread.Sleep(15);
                            start = DateTime.UtcNow;
                            end = DateTime.UtcNow;
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                    }
                });
                threads.Add(t);
                Thread tToSave = new Thread(() =>
                {
                    lock (lockedToSave)
                    {
                        b.PropertyChanged += b.Update!;
                    }
                });
                threadsToSave.Add(tToSave);
            }
        }
        public void StartThreads()
        {
            foreach(Thread t in threads)
            {
                t.Start();
            }
            foreach(Thread t in threadsToSave)
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
            foreach (Thread t in threadsToSave)
            {
                t.Interrupt();
            }
            lock(lockedToSave)
            {
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