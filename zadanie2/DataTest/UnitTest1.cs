using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestData
{
    [TestClass]
    public class BallTest
    {
        private DataAbstractApi DataApi;
        [TestMethod]
        public void createIBallTest()
        {
            
            DataApi = DataAbstractApi.CreateDataLayer();
            DataApi.createBalls(1);
            Assert.IsTrue(DataApi.GetBall(0).X >= 10 && DataApi.GetBall(0).X <= DataApi.BoardWidth - 10);
            Assert.IsTrue(DataApi.GetBall(0).Y>= 10 && DataApi.GetBall(0).Y <= DataApi.BoardHeight - 10);

            Assert.IsTrue(DataApi.GetBall(0).R == 20);
            Assert.IsTrue(DataApi.GetBall(0).Weight == 50);
            Assert.IsTrue(DataApi.GetBall(0).XSpeed >= 0.1 && DataApi.GetBall(0).XSpeed <= 1.1);
            Assert.IsTrue(DataApi.GetBall(0).YSpeed >= 0.1 && DataApi.GetBall(0).YSpeed <= 1.1);

            DataApi = DataAbstractApi.CreateDataLayer();
            DataApi.createBalls(1);
            double x = DataApi.GetBall(0).X;
            double y = DataApi.GetBall(0).Y;
            DataApi.GetBall(0).XSpeed = 5;
            DataApi.GetBall(0).YSpeed = 5;
            DataApi.GetBall(0).Move();
            Assert.AreNotEqual(x, DataApi.GetBall(0).X);
            Assert.AreNotEqual(y, DataApi.GetBall(0).Y);

            DataApi.GetBall(0).X = 10;
            DataApi.GetBall(0).Y = 17;
            DataApi.GetBall(0).XSpeed = 4;
            DataApi.GetBall(0).YSpeed = -3;
            Assert.AreEqual(10, DataApi.GetBall(0).X);
            Assert.AreEqual(17, DataApi.GetBall(0).Y);
            Assert.AreEqual(4, DataApi.GetBall(0).XSpeed);
            Assert.AreEqual(-3, DataApi.GetBall(0).YSpeed);
        }        
    }
}