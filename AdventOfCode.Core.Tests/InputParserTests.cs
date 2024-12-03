namespace AdventOfCode.Core.Tests;

public class InputParserTests
{
    [Test, Parallelizable]
    public void TestIntMatrix() {
        var input =
            """
            1 2 3
            4 5 6
            """;
        int[][] parsed = InputParser.ParseIntMatrix(input);
        int[][] expected = [[1,2,3],[4,5,6]];
        Assert.That(parsed, Is.EqualTo(expected));
    }
}