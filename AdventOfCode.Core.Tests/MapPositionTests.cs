namespace AdventOfCode.Core.Tests;

public class MapPositionTests
{
    [Test]
    public void TestUp() =>
                Assert.That(new MapPosition(1, 1).Up, Is.EqualTo(new MapPosition(0, 1)));

    [Test]
    public void TestDown() =>
                Assert.That(new MapPosition(1, 1).Down, Is.EqualTo(new MapPosition(2, 1)));

    [Test]
    public void TestLeft() =>
                Assert.That(new MapPosition(1, 1).Left, Is.EqualTo(new MapPosition(1, 0)));

    [Test]
    public void TestRight() =>
                Assert.That(new MapPosition(1, 1).Right, Is.EqualTo(new MapPosition(1, 2)));

    [Test]
    public void TestUpRight() =>
                Assert.That(new MapPosition(1, 1).UpRight, Is.EqualTo(new MapPosition(0, 2)));

    [Test]
    public void TestUpLeft() =>
                Assert.That(new MapPosition(1, 1).UpLeft, Is.EqualTo(new MapPosition(0, 0)));

    [Test]
    public void TestDownRight() =>
                Assert.That(new MapPosition(1, 1).DownRight, Is.EqualTo(new MapPosition(2, 2)));

    [Test]
    public void TestDownLeft() =>
                Assert.That(new MapPosition(1, 1).DownLeft, Is.EqualTo(new MapPosition(2, 0)));
    
}