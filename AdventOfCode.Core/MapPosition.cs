namespace AdventOfCode.Core;

public readonly record struct MapPosition(int Row, int Column) : IEquatable<(int,int)>, IComparable<MapPosition>
{
    public MapPosition Left      => this with { Column = Column - 1 };
    public MapPosition Right     => this with { Column = Column + 1 };
    public MapPosition Up        => this with { Row = Row - 1 };
    public MapPosition Down      => this with { Row = Row + 1 };
    public MapPosition UpLeft    => Left with { Row = Row - 1 };
    public MapPosition UpRight   => Right with { Row = Row - 1 };
    public MapPosition DownLeft  => Left with { Row = Row + 1 };
    public MapPosition DownRight => Right with { Row = Row + 1 };

    public int CompareTo(MapPosition other) => Row.CompareTo(other.Row) switch
    {
        0 => Column.CompareTo(other.Column),
        var cmp => cmp
    };
    
    public override string ToString() => $"({Row}, {Column})";

    public bool Equals((int, int) other) => other switch {
                (int r, int c) => r == Row && c == Column
    };

    public static MapPosition Create((int Row, int Column) position) => 
        new MapPosition(position.Row, position.Column);

    public static IEnumerable<MapPosition> Create(IEnumerable<(int Row, int Column)> positions) =>
        positions.Select(p => new MapPosition(p.Row, p.Column));
    
    public static implicit operator MapPosition((int Row, int Column) position) => 
        new MapPosition(position.Row, position.Column);
}