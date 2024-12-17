using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public class Day10
{
    public static int Part1(string input) {
        var (map, adjacencies) = Parse(input);
        var startPositions = map.FindPositions(height => height == 0).ToArray();
        var sum = 0;
        foreach (var trailHead in startPositions) {
            HashSet<MapPosition> reached = [];
            var stack = new Stack<MapPosition>([trailHead]);
            while (stack.TryPop(out var current)) {
                if (map[current] == 9) {
                    reached.Add(current);
                } else {
                    foreach (var adjacent in adjacencies.GetValueOrDefault(current, [])) {
                        stack.Push(adjacent);
                    }
                }
            }
            sum += reached.Count;
        }
        return sum;
    }

    public static int Part2(string input) {
        var (map, adjacencies) = Parse(input);
        var startPositions = map.FindPositions(height => height == 0).ToArray();
        var sum = 0;
        foreach (var trailHead in startPositions) {
            var stack = new Stack<MapPosition>([trailHead]);
            while (stack.TryPop(out var current)) {
                if (map[current] == 9) {
                    sum++;
                } else {
                    foreach (var adjacent in adjacencies.GetValueOrDefault(current, [])) {
                        stack.Push(adjacent);
                    }
                }
            }
        }
        return sum;
    }

    private static (Map<int?>, Dictionary<MapPosition, MapPosition[]> ) Parse(string input) {
        static int? ParseTile(char c) => int.TryParse(c.ToString(), out var digit) ? digit : null;
        var matrix = InputParser.ParseCharMatrix(input)
                                .Select(row => row.Select(ParseTile).ToArray())
                                .ToArray();
        var map = new Map<int?>(matrix);
        var edges = new List<(MapPosition, MapPosition)>();
        for (int row = 0; row < matrix.GetLength(0); row++) {
            for (int col = 0; col < matrix[row].Length; col++) {
                var source = new MapPosition(row, col);
                var height = map[source];
                var adj = new[] { source.Up, source.Down, source.Left, source.Right };
                edges.AddRange(adj.Where(map.IsInBounds)
                                  .Where(pos => map[pos] == height + 1)
                                  .Select(target => (source, tgt: target)));
            }
        }
        var adjacencies = edges.ToLookup(t => t.Item1, t => t.Item2)
                               .ToDictionary(g => g.Key, g => g.ToArray());
        return (map, adjacencies);
    }
}