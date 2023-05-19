using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class BallDataTest
    {
        AbstractBall b = AbstractBall.CreateBall(10, 15);
        
        [TestMethod]
        public void CreateBallTest()
        {
            Assert.AreEqual(15, b.Radius);
        }
        
        [TestMethod]
        public void BallPosTest()
        {
            Assert.AreEqual(b._xPosition, 10);
            Assert.AreEqual(b._yPosition, 15);
        }
    }
}