using System;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
namespace LogicTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Constructor_Create()
        {
            Moving_the_Balls balls = new Moving_the_Balls();
            Assert.AreEqual(balls.Balls.Count, 0);
            balls.Create(10);
            Assert.AreEqual(balls.Balls.Count, 10);
        }
        [TestMethod]
        public void Test_Tasks_Start()
        { 
            Moving_the_Balls balls = new Moving_the_Balls();
            balls.Create(10);
            balls.Start();
            Assert.AreEqual(balls.Tasks, 10);
        }
        
        [TestMethod]
        public void Test_Update()
        {
            Random rand = new Random();
            ObservableCollection<Ball> balls_obs = new ObservableCollection<Ball>();
            Moving_the_Balls balls = new Moving_the_Balls();
            balls_obs = balls.Create(1);
            Ball ball = new Ball(balls_obs[0].X, balls_obs[0].Y);
            balls.Update(ball);
            Thread.Sleep(50);
            Assert.AreNotEqual(ball.X, balls_obs[0].X);
            Assert.AreNotEqual(ball.Y, balls_obs[0].Y);
        }
    }
}