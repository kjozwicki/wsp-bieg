using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    
    [TestClass]
    public class BoardTest
    {
        private DataAbstractAPI _board = DataAbstractAPI.CreateAPI();
        
        [TestMethod]
        public void GetWidthTest()
        {
            _board.CreateBoardWithBalls(0, 500, 0);
            Assert.AreEqual(_board.GetBoardWidth(), 500);
        }

        [TestMethod]
        public void GetHeightTest()
        {
            _board.CreateBoardWithBalls(0, 0, 1000);
            Assert.AreEqual(_board.GetBoardHeight(), 1000);
        }
    }
}

