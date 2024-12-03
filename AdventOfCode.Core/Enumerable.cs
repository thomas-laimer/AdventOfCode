namespace AdventOfCode.Core;

public static class Enumerable
{
    public static IEnumerable<TResult> Pairwise<TSource, TResult>(
                this IEnumerable<TSource> source, 
                Func<TSource, TSource, TResult> selector) {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(selector);
        var array = source switch { TSource[] a => a, var other => other.ToArray() };
        for (int i = 0; i < array.Length-1; i++) {
            yield return selector(array[i], array[i + 1]);
        }
    }

    public static IEnumerable<int> Indices<T>(this IEnumerable<T> source) {
        ArgumentNullException.ThrowIfNull(source);
        return System.Linq.Enumerable.Range(0, source.Count());
    }

    public static IEnumerable<TSource> SkipAt<TSource>(this IEnumerable<TSource> source, int index) {
        ArgumentNullException.ThrowIfNull(source);
        return source.Where((_, i) => i != index);
    }
}