using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public static class Day6
{
    private static char[] GuardTiles = ['^', '>', 'v', '<'];
    public static int Part1(string input) {
        var map = new Map<char>(InputParser.ParseCharMatrix(input));
        var pos = map.FindPosition(GuardTiles.Contains);
        var visited = new HashSet<MapPosition> { pos };
        var guard = map[pos];
        while (TryMoveNext(map, ref pos, ref guard)) {
            visited.Add(pos);
        }
        return visited.Count;
    }

    // stupid brute force is still enough to crack this
    public static int Part2(string input) {
        var map = new Map<char>(InputParser.ParseCharMatrix(input));
        var startPosition = map.FindPosition(GuardTiles.Contains);
        var guardStart = map[startPosition];
        var result = 0;
        for (int row = 0; row < map.Rows; row++) {
            for (int col = 0; col < map.Columns; col++) {
                var original = map[row, col];
                if (map[row,col] == '#')
                    continue;
                map[row, col] = '#';
                
                var visited = new HashSet<(MapPosition, char)> { (startPosition, guardStart) };
                var guard = guardStart;
                var pos = startPosition;
                while (TryMoveNext(map, ref pos, ref guard)) {
                    if (visited.Contains((pos, guard))) {
                        result += 1;
                        break;
                    } else {
                        visited.Add((pos, guard));
                    }
                }
                
                map[row, col] = original;
            }
        }
        return result;

    }

    private static bool TryMoveNext(Map<char> map, ref MapPosition pos, ref char guard) {
        MapPosition Ahead(MapPosition position, char orientation) => orientation switch {
                    '^' => position.Up, 
                    '>' => position.Right, 
                    'v' => position.Down
                  , '<' => position.Left
        };
        var ahead = Ahead(pos, guard);
        while (map.IsInBounds(ahead) && map[ahead] == '#') {
            guard = guard switch { '^' => '>', '>' => 'v', 'v' => '<', '<' => '^' };
            ahead = Ahead(pos, guard);
        }
        if (map.IsInBounds(ahead)) {
            pos = ahead;
            return true;
        } else {
            return false;
        }
    }
}