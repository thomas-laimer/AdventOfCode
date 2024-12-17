namespace AdventOfCode.Core.Tests;

public class MapTests
{
    [Test]
    public void DiagonalsTest() {
        string[][] map = [
                    ["00", "01", "02"],
                    ["10", "11", "12"],
                    ["20", "21", "22"],
        ];
        var diagonals = new Map<string>(map).IndexDiagonals();
        var expected = new (int, int)[][] {
                    [(0,0)],
                    [(1,0), (0,1)],
                    [(2,0), (1,1), (0,2)],
                    
                    [(2,1), (1,2)],
                    [(2,2)],
                    
                    [(0,0), (1,1), (2,2)],
                    [(0,1), (1,2)],
                    [(0,2)],
                    
                    [(1,0), (2,1)],
                    [(2,0)]
                    
        };
        Assert.That(diagonals[0], Is.EquivalentTo(expected[0]));
        Assert.That(diagonals[1], Is.EquivalentTo(expected[1]));
        Assert.That(diagonals[2], Is.EquivalentTo(expected[2]));
        Assert.That(diagonals[3], Is.EquivalentTo(expected[3]));
        Assert.That(diagonals[4], Is.EquivalentTo(expected[4]));
        Assert.That(diagonals[5], Is.EquivalentTo(expected[5]));
        Assert.That(diagonals[6], Is.EquivalentTo(expected[6]));
        Assert.That(diagonals[7], Is.EquivalentTo(expected[7]));
        Assert.That(diagonals[8], Is.EquivalentTo(expected[8]));
        Assert.That(diagonals[9], Is.EquivalentTo(expected[9]));
        // Assert.That(diagonals, Is.EquivalentTo(expected));
    }
}