using System.Text.RegularExpressions;

namespace AdventOfCode.Core;

public static class InputParser
{
    public static string Normalize(string line) {
        ArgumentException.ThrowIfNullOrWhiteSpace(line);
        return line.Replace("\r\n", Environment.NewLine);
    }

    public static string[] SplitLines(this string str) {
        ArgumentNullException.ThrowIfNullOrWhiteSpace(str);
        return Normalize(str).Split(Environment.NewLine);
    }
    
    public static int[][] ParseIntMatrix(string input) => 
        ParseIntMatrix(input, new Regex(@"\s*\|\s*|,\s?|\s+"));
    
    public static int[][] ParseIntMatrix(string input, Regex separator) {
        return Normalize(input)
            .Split(Environment.NewLine)
            .Select(line => separator.Split(line))
            .Select(line => line.Select(int.Parse))
            .Select(line => line.ToArray())
            .ToArray();
    }
    public static int[][] ParseIntLists(string input) =>
        ParseIntLists(input, new Regex(@"\s+"));
    
    public static int[][] ParseIntLists(string input, Regex separator) {
        return Normalize(input)
            .Split(Environment.NewLine)
            .Select(line => separator.Split(line))
            .Select(line => line.Select(int.Parse))
            .Select(line => line.ToArray())
            .ToArray();
    }

}