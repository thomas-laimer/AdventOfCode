using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day11
{
    public static long Part1(string input, int blinks)
    {
        var stones = InputParser.ParseIntLists(input).First().Select(i => (long)i).ToList();
        for (int i = 0; i < blinks; i++)
        {
            var next = new List<long>();
            for (int k = 0; k < stones.Count; k++)
            {
                next.AddRange(ApplyRules(stones[k]));
            }
            stones = next;
        }

        return stones.Count;
    }

    private static Dictionary<long, long[]> Memoization = new Dictionary<long, long[]>();

    private static long[] ApplyRules(long stone)
    {
        if (!Memoization.TryGetValue(stone, out var result))
        {
            if (stone == 0)
                result = [1];
            else
            {
                var str = stone.ToString();
                if (str.Length % 2 == 0)
                {
                    var middle = str.Length / 2;
                    var left = long.Parse(str[..middle]);
                    var right = long.Parse(str[middle..]);
                    result = [left, right];
                }
                else
                {
                    result = [stone * 2024L];
                }
            }

            Memoization.Add(stone, result);
        }

        return result;
    }
}