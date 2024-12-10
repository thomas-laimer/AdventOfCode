namespace AdventOfCode.Year2024.Tests;

public class Day4Tests
{
    [Test]
    public void TestPart1Sample() {
        var expected = 18;
        var actual = Day4.Part1(SampleInput);
        Assert.That(actual, Is.EqualTo(expected));
    }

    private static string SampleInput =
                """
                MMMSXXMASM
                MSAMXMSMSA
                AMXSXMAAMM
                MSAMASMSMX
                XMASAMXAMM
                XXAMMXXAMA
                SMSMSASXSS
                SAXAMASAAA
                MAMMMXMMMM
                MXMXAXMASX
                """;
}