using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BallDataTest
    {
        Ball _ball = new Ball(0, 0);
        
        [TestMethod]
        public void CreateBallTest()
        {
            Assert.AreEqual(15, _ball.Radius);
        }

        [TestMethod]
        public void SetBallSpeedTest()
        {
            _ball.XSpeed = 2;
            _ball.YSpeed = 3;
            Assert.AreEqual(2, _ball.XSpeed);
            Assert.AreEqual(3, _ball.YSpeed);
        }
        
        [TestMethod]
        public void BallPosTest()
        {
            Ball b = new(10, 15);
            Assert.AreEqual(b._xPosition, 10);
            Assert.AreEqual(b._yPosition, 15);
        }
    }
}