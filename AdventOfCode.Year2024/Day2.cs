using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day2
{
    public static int Part1(string input) {
        var records = InputParser.ParseIntLists(input);
        return records.Count(IsSafe);
    }
    public static int Part2(string input) {
        var records = InputParser.ParseIntLists(input);
        return records.Count(IsSafeWithDampening);    
    }

    private static bool IsSafe(int[] record) {
        var deltas = record.Pairwise((a,b) => a-b);
        var isSafeIncr = deltas.All(delta => delta < 0 && Math.Abs(delta) is >= 1 and <= 3);
        var isSafeDecr = deltas.All(delta => delta > 0 && Math.Abs(delta) is >= 1 and <= 3);
        return isSafeIncr || isSafeDecr;
    }

    private static bool IsSafeWithDampening(int[] record) {
        if (IsSafe(record)) {
            return true;
        }
        // is there any index i for a level that can be dampened
        return record.Indices().Any(i => IsSafe(record.SkipAt(i).ToArray()));
    }
    
}