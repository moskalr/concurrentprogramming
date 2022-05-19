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
            Assert.IsNotNull(DataApi.GetAll());
            DataApi.GetBall(0).X = 140;
            Assert.AreEqual(DataApi.GetBall(0).X, 140);
            DataApi.GetBall(0).Y = 100;
            Assert.AreEqual(DataApi.GetBall(0).Y, 100);
            DataApi.GetBall(0).R = 20;
            Assert.AreEqual(DataApi.GetBall(0).R, 20);
            DataApi.GetBall(0).YSpeed = 3;
            Assert.AreEqual(DataApi.GetBall(0).YSpeed, 3);
            DataApi.GetBall(0).XSpeed = 5;
            Assert.AreEqual(DataApi.GetBall(0).XSpeed, 5);
            DataApi.GetBall(0).Move();
            Assert.AreEqual(DataApi.GetBall(0).X, 145);
            Assert.AreEqual(DataApi.GetBall(0).Y, 103);
            
            Assert.IsTrue(DataApi.GetBall(0).X >= 10 && DataApi.GetBall(0).X <= DataApi.BoardWidth - 10);
            Assert.IsTrue(DataApi.GetBall(0).Y>= 10 && DataApi.GetBall(0).Y <= DataApi.BoardHeight - 10);

            Assert.IsTrue(DataApi.GetBall(0).R == 20);
            Assert.IsTrue(DataApi.GetBall(0).Weight == 50);
            

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
        [TestMethod]
        public void CreateDataApiTest()
        {
            DataApi = DataAbstractApi.CreateDataLayer();
            Assert.IsNotNull(DataApi);
        }

        [TestMethod]
        public void BoardWidthHeight()
        {
            DataApi = DataAbstractApi.CreateDataLayer();
            DataApi.BoardWidth = 500;
            DataApi.BoardHeight = 400;
            Assert.AreEqual(500, DataApi.BoardWidth);
            Assert.AreEqual(400, DataApi.BoardHeight);
        }

        [TestMethod]
        public void CreateBalls()
        {
            DataApi = DataAbstractApi.CreateDataLayer();
            DataApi.createBalls(5);
            Assert.IsNotNull(DataApi.GetAll());
            Assert.AreEqual(5, DataApi.Count());
            DataApi.createBalls(10);
            Assert.IsNotNull(DataApi.GetAll());
            Assert.AreEqual(10, DataApi.Count());
        }

        [TestMethod]
        public void GetBallTest()
        {
            DataApi = DataAbstractApi.CreateDataLayer();
            DataApi.createBalls(10);
            for (int i = 0; i < 10; i++)
                Assert.IsNotNull(DataApi.GetBall(i));
        }
    }
}