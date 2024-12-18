namespace AdventOfCode.Core.Tests;

public class MapTests
{
    public class FloodFill
    {
        private static Map<char> simpleMap = new Map<char>(InputParser.ParseCharMatrix(
            """
            AAAA
            BBCD
            BBCC
            EEEC
            """));
        
        [Test]
        public void TestSingleRow()
        {
            Assert.That(simpleMap.FloodFill((0, 0)),
                Is.EquivalentTo(new HashSet<MapPosition>([(0, 0), (0, 1), (0, 2), (0, 3)])));
        }

        [Test]
        public void TestRectangle()
        {
            Assert.That(simpleMap.FloodFill((1, 0)),
                Is.EquivalentTo(new HashSet<MapPosition>([(1, 0), (1, 1), (2, 0), (2, 1)])));
        }

        [Test]
        public void TestComplexShape()
        {
            Assert.That(simpleMap.FloodFill((1, 2)),
                Is.EquivalentTo(new HashSet<MapPosition>([(1, 2), (2, 2), (2, 3), (3, 3)])));
        }
    }
    
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

    [Test]
    public void TestSimpleFloodFill()
    {
        var map = new Map<char>(InputParser.ParseCharMatrix("""
                                                            AAAA
                                                            BBCD
                                                            BBCC
                                                            EEEC
                                                            """));
        var aRegion = new HashSet<MapPosition>(map.Positions.Where(pos => map[pos] == 'A'));
        var bRegion = new HashSet<MapPosition>(map.Positions.Where(pos => map[pos] == 'B'));
        var cRegion = new HashSet<MapPosition>(map.Positions.Where(pos => map[pos] == 'C'));
        var dRegion = new HashSet<MapPosition>(map.Positions.Where(pos => map[pos] == 'D'));
        var eRegion = new HashSet<MapPosition>(map.Positions.Where(pos => map[pos] == 'E'));

        Assert.That(map.FloodFill(aRegion.First()), Is.EquivalentTo(aRegion));
        Assert.That(map.FloodFill(bRegion.First()), Is.EquivalentTo(bRegion));
        Assert.That(map.FloodFill(cRegion.First()), Is.EquivalentTo(cRegion));
        Assert.That(map.FloodFill(dRegion.First()), Is.EquivalentTo(dRegion));
    }
}