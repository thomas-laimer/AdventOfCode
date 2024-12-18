namespace AdventOfCode.Year2024.Tests;

public class Day11Tests
{
    [Test]
    public void TestPart1(){
        Assert.That(Day11.Part1("125 17", 6), Is.EqualTo(22));
    }

    [Test]
    public void TestPart1InputFile()
    {
        Assert.That(Day11.Part1("554735 45401 8434 0 188 7487525 77 7", 209412), Is.EqualTo(0));
    }
    
    
    [Test]
    public void TestPart2InputFile()
    {
        Assert.That(Day11.Part1("554735 45401 8434 0 188 7487525 77 7", 75), Is.EqualTo(0));
    }
}