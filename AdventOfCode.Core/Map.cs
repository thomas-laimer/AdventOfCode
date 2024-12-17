using System.Collections;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace AdventOfCode.Core;

public class Map<T>
{
    private readonly T[][] map;
    public int Rows    => map.Length;
    public int Columns => map[0].Length;
    
    public Map(T[][] map) {
        ArgumentNullException.ThrowIfNull(map, nameof(map));
        for (int i = 0; i < map.Length; i++) {
            ArgumentNullException.ThrowIfNull(map[i], $"{nameof(map)}[{i}]");
            if (map[i].Length != map[0].Length) {
                throw new ArgumentException($"Map[{i}] does not have the same length as the rest.");
            }
        }
        this.map = map;
    }

    public T this[int row, int column] {
        get => map[row][column];
        set => map[row][column] = value;
    }
    public T this[MapPosition position] {
        get => this[position.Row, position.Column];
        set => this[position.Row, position.Column] = value;
    }

    public T this[(int row, int column) position] {
        get => this[position.row, position.column];
        set => this[position.row, position.column] = value;
    }
    
    public bool IsInBounds(MapPosition pos) =>
                pos.Row >= 0 && pos.Row < Rows && pos.Column >= 0 && pos.Column < Columns;

    public MapPosition FindPosition(Predicate<T> predicate) {
        for (int i = 0; i < Rows; i++) {
            for (int k = 0; k < Columns; k++) {
                if (predicate(map[i][k])) {
                    return new MapPosition(i, k);
                }
            }
        }
        throw new InvalidOperationException("No such position");
    }

    public IEnumerable<MapPosition> FindPositions(Predicate<T> predicate) {
        for (int i = 0; i < Rows; i++) {
            for (int k = 0; k < Columns; k++) {
                if (predicate(map[i][k])) {
                    yield return new MapPosition(i, k);
                }
            }
        }
    }

    private IEnumerable<MapPosition>  Diagonal(int row, int col, Func<MapPosition, MapPosition> next) {
        var position = new MapPosition(row, col);
        while (IsInBounds(position)) {
            yield return position;
            position = next(position);
        }
    }

    public MapPosition[][] IndexDiagonals() {
        var result = new List<MapPosition[]>();
        // / diagonals from left column
        for (int row = 0; row < Rows; row++) {
            result.Add(Diagonal(row,0, pos => pos.UpRight).ToArray());
        }
        for (int col = 1; col < Columns; col++) {
            result.Add(Diagonal(Rows-1, col, pos => pos.UpRight).ToArray());
        }
        for (int col = 0; col < Columns; col++) {
            result.Add(Diagonal(0, col, pos => pos.DownRight).ToArray());
        }
        for (int row = 1; row < Rows; row++) {
            result.Add(Diagonal(row, 0, pos => pos.DownRight).ToArray());
        }
        return result.ToArray();
    }
    //     
    //     // left column, upwards
    //     for (var row = 0; row < Rows; row++) {
    //         var diagonal = new List<MapPosition>();
    //         for (var pos = new MapPosition(row, 0); IsInBounds(pos); pos = pos.UpRight) {
    //             diagonal.Add(pos);
    //         }
    //         result.Add(diagonal.ToArray());
    //     }
    //     
    //     for (var col = 1; col < Columns; col++) {
    //         var diagonal = new List<MapPosition>();
    //         for (var pos = new MapPosition(Rows - 1, 1); IsInBounds(pos); pos = pos.UpRight) {
    //             diagonal.Add(pos);
    //         }
    //         result.Add(diagonal.ToArray());
    //     }
    //
    //     for (var col = 0; col < Columns; col++) {
    //         var diagonal = new List<MapPosition>();
    //         for (var pos = new MapPosition(0, col); IsInBounds(pos); pos = pos.DownRight) {
    //             diagonal.Add(pos);
    //         }
    //         result.Add(diagonal.ToArray());
    //     }
    //     
    //     for (int row = 1; row < Rows; row++) {
    //         var diagonal = new List<MapPosition>();
    //         for (var pos = new MapPosition(row, 0); IsInBounds(pos); pos = pos.DownRight) {
    //             diagonal.Add(pos);
    //         }
    //         result.Add(diagonal.ToArray());
    //     }
    //
    //     return result.ToArray(); 
    // }
    
    
    
    [Conditional("DEBUG")]
    public void PrintDebug() {
        for (int i = 0; i < Rows; i++) {
            var row = map[i];
            var line = row switch {
                        char[] charArray => new string(charArray)
                      , IEnumerable<T> enumerable => string.Join("", enumerable)
            };
            Debug.WriteLine(line);
        }
    }
}

