namespace AdventOfCode.Core;

public readonly record struct MapPosition(int Row, int Column) : IEquatable<(int,int)>
{
    public MapPosition Left      => this with { Column = Column - 1 };
    public MapPosition Right     => this with { Column = Column + 1 };
    public MapPosition Up        => this with { Row = Row - 1 };
    public MapPosition Down      => this with { Row = Row + 1 };
    public MapPosition UpLeft    => Left with { Row = Row - 1 };
    public MapPosition UpRight   => Right with { Row = Row - 1 };
    public MapPosition DownLeft  => Left with { Row = Row + 1 };
    public MapPosition DownRight => Right with { Row = Row + 1 };
    
    public override string ToString() => $"({Row}, {Column})";

    public bool Equals((int, int) other) => other switch {
                (int r, int c) => r == Row && c == Column
    };
}