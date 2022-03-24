using NUnit.Framework;

namespace Test1;

public class Tests
{
    double x = 3.3;
    double y = 3.2;
    double wynik = 6.5;
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void TestAdd()
    {
        //problem z precyzja po przecinku dlatego jest wykorzystana funkcja within
        Assert.That(Program.dzialania(1,x,y), Is.EqualTo(6.5));
    }
    [Test]
    public void TestSub()
    {
        Assert.That(Program.dzialania(2, x, y), Is.EqualTo(0.1).Within(0.001));
    }
    [Test]
    public void TestDiv()
    {
        Assert.That(Program.dzialania(3, x, y), Is.EqualTo(1.03125).Within(0.0001));
    }
    [Test]
    public void TestMul()
    {
        Assert.That(Program.dzialania(4, x, y), Is.EqualTo(10.56));
    }
}