using Data;

namespace DataTests
{
    public class BallDataTest
    {
        private BallData _ball = new BallData(0, 0, 1, 2, 1, 10);
        
        public void CreateBallTest()
        {
            Assert.AreEqual(1, _ball.XSpeed);
            Assert.AreEqual(10, _ball.YSpeed);
            Assert.AreEqual(1, _ball.Radius);
            Assert.AreEqual(2, _ball.Weight);
        }
        
        public void SetBallSpeedTest()
        {
            _ball.XSpeed = 2;
            _ball.YSpeed = 3;
            Assert.AreEqual(2, _ball.XSpeed);
            Assert.AreEqual(3, _ball.YSpeed);
        }
    }
}