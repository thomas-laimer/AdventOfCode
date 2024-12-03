using System.Diagnostics;
using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day1
{
    private static (int[] left, int[] right) ParseInput(string input) {
        var matrix = InputParser.ParseIntMatrix(input);
        var columns = Matrix.Transpose(matrix);
        Debug.Assert(columns.Length == 2);
        var left = columns[0];
        var right = columns[1];
        return (left, right);
    }

    public static int Part1(string input)
    {
        var (left, right) = ParseInput(input);
        Debug.Assert(left.Length == right.Length);
        Array.Sort(left);
        Array.Sort(right);
        // zip allows you to operate on each element in two IEnumerables pairwise
        return left.Zip(right, (eLeft, eRight) => Math.Abs(eLeft - eRight)).Sum();
    }

    public static int Part2(string input)
    {
        var (left, right) = ParseInput(input);
        var histogram = Histogram.Compute(right);
        return left.Sum(element => histogram[element] * element);
    }
    
}