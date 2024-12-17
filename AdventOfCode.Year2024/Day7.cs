using System.Diagnostics;
using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day7
{
    public static long Part1(string input) =>
                Compute(input, [Add, Mul]);

    public static long Part2(string input) =>
                Compute(input, [Add, Mul, Concat]);

    private static long Compute(string input, Func<long, long, long>[] operators) {
        var equations = ParseInput(input);
        return equations.Where(eq => TestEquation(eq.Result, 0, eq.Operands, 0, operators))
                        .Sum(eq => eq.Result);
    }

    private static long Add(long a, long b) => a + b;
    private static long Mul(long a, long b) => a * b;
    private static long Concat(long a, long b) => long.Parse(string.Join("", a, b));

    static bool TestEquation(long expectedResult, long partialResult, int[] operands, int index,
                             Func<long, long, long>[] operators) {
        if (index == operands.Length) {
            return expectedResult == partialResult;
        }
        Debug.Assert(index < operands.Length);
        var next = operands[index];
        foreach (var op in operators) {
            var nextPartial = op(partialResult, next);
            if (TestEquation(expectedResult, nextPartial, operands, index + 1, operators)) {
                return true;
            }
        }
        return false;
    }

    private static (long Result, int[] Operands)[] ParseInput(string input) {
        var lines = InputParser.Normalize(input).SplitLines();
        var result = new List<(long Result, int[] Operands)>();
        foreach (var line in lines) {
            var parts = line.Split(':', StringSplitOptions.TrimEntries);
            var lineResult = long.Parse(parts[0]);
            var lineOperands = parts[1].Split(' ').Select(int.Parse).ToArray();
            result.Add((lineResult, lineOperands));
        }
        return result.ToArray();
    }
}