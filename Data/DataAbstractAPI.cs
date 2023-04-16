using System;
using System.Collections.Generic;

namespace Data
{
    public abstract class DataAbstractAPI
    {
        public abstract void Connect();

        public abstract void CreateBoardWithBalls(int amount, double widthOfCanvas, double heightOfCanvas);

        public abstract List<Ball> GetBalls();

        public abstract void InterruptThreads();
        
        public abstract void StartThreads();

        public abstract double GetBoardWidth();

        public abstract double GetBoardHeight();

        public static DataAbstractAPI CreateAPI()
        {
            return new API();
        }

        private class API : DataAbstractAPI
        {
            private Board board;

            public override void Connect()
            {
                throw new NotImplementedException();
            }

            public override void CreateBoardWithBalls(int amount, double widthOfCanvas, double heightOfCanvas)
            {
                this.board = new Board(amount, widthOfCanvas, heightOfCanvas);
            }

            public override List<Ball> GetBalls()
            {
                return board.GetBalls();
            }

            public override void InterruptThreads()
            {
                board.InterruptThreads();
            }
            
            public override void StartThreads()
            {
                board.StartThreads();
            }

            public override double GetBoardHeight()
            {
                return board.GetBoardHeight();
            }

            public override double GetBoardWidth()
            {
                return board.GetBoardWidth();
            }

        }
    }
}