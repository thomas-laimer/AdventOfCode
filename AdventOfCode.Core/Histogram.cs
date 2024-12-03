using System.Collections;

namespace AdventOfCode.Core;

public class Histogram<T> where T: notnull
{
    private Dictionary<T, int> Dict { get; }

    private Histogram() {
        Dict = new();
    }
    
    public Histogram(IEnumerable<T> values) : this() {
        foreach (var value in values) {
            int count = Dict.GetValueOrDefault(value, 0);
            Dict[value] = count + 1;
        }
    }

    public int this[T key] => Dict.GetValueOrDefault(key, 0);
}

public class Histogram
{
    public static Histogram<T> Compute<T>(IEnumerable<T> values) where T:notnull => 
        new(values);
}