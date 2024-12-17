using System.Diagnostics;
using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day7
{
    private static long Add(long a, long b) => a + b;
    private static long Mul(long a, long b) => a * b;
    private static long Concat(long a, long b) => long.Parse(string.Join("", a, b));
    public static long Part1(string input) {
        var equations = ParseInput(input);
        long checksum = 0;
        foreach (var (result, operands) in equations) {
            if (TestEquation(result, 0, operands, 0, [Add,Mul])) {
                checksum += result;
            }
        }
        return checksum;
    }

    public static long Part2(string input) {
        var equations = ParseInput(input);
        long checksum = 0;
        foreach (var (result, operands) in equations) {
            if (TestEquation(result, 0, operands, 0, [Add,Mul, Concat])) {
                checksum += result;
            }
        }
        return checksum;
    }
    static bool TestEquation(long expectedResult, long partialResult, int[] operands, int index, 
                             Func<long,long,long>[] operators) {
        if (index == operands.Length) {
            return expectedResult == partialResult;
        }
        Debug.Assert(index < operands.Length); 
        var next = operands[index];
        foreach (var op in operators) {
            var nextPartial = op(partialResult, next);
            if (TestEquation(expectedResult, nextPartial, operands, index+1, operators)){
                return true;
            }
        }
        return false;
    }

    private static (long Result, int[] Operands)[] ParseInput(string input) {
        var lines =  InputParser.Normalize(input).SplitLines();
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