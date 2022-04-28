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
            double x;
            double y;
            Random rand = new Random();
            Moving_the_Balls creator = new Moving_the_Balls();
            ObservableCollection<Ball> balls_obs = new ObservableCollection<Ball>();
            Ball ball = new Ball();
            x = rand.Next(10, 604);
            y = rand.Next(10, 384);
            balls_obs.Add(new Ball(x, y));
            creator.Create(1);
            creator.Update(ball, 10, 10);
            Thread.Sleep(50);
            Assert.AreNotEqual(10, balls_obs[0].X);
            Assert.AreNotEqual(10, balls_obs[0].Y);
        }
    }
}