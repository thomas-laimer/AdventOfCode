using System;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day3
{
    private static Regex MultiplyPattern = new Regex(@"mul\((\d{1,3}),(\d{1,3})\)");
    private static Regex DoPattern = new Regex(@"do\(\)");
    private static Regex DontPattern = new Regex(@"don't\(\)");

    private static int Multiply(Match match) {
        var a = int.Parse(match.Groups[1].Value);
        var b = int.Parse(match.Groups[2].Value);
        return a * b;
    }
    
    public static int Part1(string input) {
        input = InputParser.Normalize(input);
        var matches = MultiplyPattern.Matches(input);
        return matches.Sum(Multiply);
    }

    public static int Part2(string input) {
        input = InputParser.Normalize(input);
        var muls = MultiplyPattern.Matches(input);
        var dos = DoPattern.Matches(input);
        var donts = DontPattern.Matches(input);
        var matches = muls.Concat(dos).Concat(donts).OrderBy(match => match.Index);
        var isEnabled = true;
        int result = 0;
        foreach (var match in matches.OrderBy(m => m.Index)) {
            if (match.Value.StartsWith("mul")) {
                if (isEnabled) {
                    result += Multiply(match);
                }
            } else if (match.Value == "don't()") {
                isEnabled = false;
            } else if (match.Value == "do()") {
                isEnabled = true;
            } else {
                throw new Exception($"Unrecognized value: {match.Value}");
            }
        }
        return result;
    }
}