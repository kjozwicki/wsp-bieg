using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BallDataTest
    {
        Ball _ball = new Ball(0, 0, 1,  1, 10);
        
        [TestMethod]
        public void CreateBallTest()
        {
            Assert.AreEqual(1, _ball.XSpeed);
            Assert.AreEqual(10, _ball.YSpeed);
            Assert.AreEqual(1, _ball.Radius);
        
        }
        
        [TestMethod]
        public void SetBallSpeedTest()
        {
            _ball.XSpeed = 2;
            _ball.YSpeed = 3;
            Assert.AreEqual(2, _ball.XSpeed);
            Assert.AreEqual(3, _ball.YSpeed);
        }
    }
}