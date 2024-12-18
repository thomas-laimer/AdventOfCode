using System.Diagnostics;
using System.Net.Http.Headers;

namespace AdventOfCode.Core;

public static class EnumerableExtensions
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

    public static Queue<TSource> ToQueue<TSource>(this IEnumerable<TSource> source) {
        ArgumentNullException.ThrowIfNull(source);
        return new Queue<TSource>(source);
    }

    public static (T Min, T Max) MinMax<T>(this IEnumerable<T> source) where T: IComparable<T> 
    {
        ArgumentNullException.ThrowIfNull(source);
        var comparables = source as T[] ?? source.ToArray();
        if (comparables.Length == 0)
        {
            throw new InvalidOperationException("The source sequence is empty.");
        } 
        T min = comparables[0], max = comparables[0];
        for (int i = 1; i < comparables.Length; i++)
        {
            var item = comparables[i];
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }

            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return (min, max);
    }

    public static (TValue Min, TValue Max) MinMaxBy<TSource, TValue>(this IEnumerable<TSource> source,
        Func<TSource, TValue> selector) where TValue : IComparable<TValue>
    {
        return source.Select(selector).MinMax();
    }
}