using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        double x = 3.3;
        double y = 3.2;
        [TestMethod]
        public void TestMethod_Add()
        {
            //problem z precyzja po przecinku dlatego jest wykorzystana funkcja within
            NUnit.Framework.Assert.That(Program.dzialania(1, x, y), Is.EqualTo(6.5).Within(0.0001));
        }
        [TestMethod]
        public void TestMethod_Sub()
        {
            NUnit.Framework.Assert.That(Program.dzialania(2, x, y), Is.EqualTo(0.1).Within(0.0001));
        }
        [TestMethod]
        public void TestMethod_Div()
        {
            NUnit.Framework.Assert.That(Program.dzialania(3, x, y), Is.EqualTo(1.03125).Within(0.0001));
        }
        [TestMethod]
        public void TestMethod_Mul()
        {

            NUnit.Framework.Assert.That(Program.dzialania(4, x, y), Is.EqualTo(10.56).Within(0.0001));
        }
    }
}