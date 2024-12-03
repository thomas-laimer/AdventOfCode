using NUnit.Framework;

namespace AdventOfCode.Core.Tests;

public class EnumerableTests
{
    [Test, Parallelizable]
    public void TestIndicesArray() {
        
        int[] array = [1, 2, 3];
        int[] indices = array.Indices().ToArray();
        int[] expected = [0, 1, 2];
        Assert.That(indices, Is.EqualTo(expected));
    }
    
    [Test, Parallelizable]
    public void TestIndicesEnumerable() {
        var values = System.Linq.Enumerable.Range(1, 3);
        int[] indices = values.Indices().ToArray();
        int[] expected = [0, 1, 2];
        Assert.That(indices, Is.EqualTo(expected));
    }

    [Test, Parallelizable]
    public void TestPairWise() {
        // 7 6 4 2 1
        int[] array = [7, 6, 4, 2, 1];
        (int, int)[] expected = [(7, 6), (6, 4), (4, 2), (2, 1)];
        var pairs = array.Pairwise(ValueTuple.Create).ToArray();
        Assert.That(pairs, Is.EqualTo(expected));
    }

    [Test, Parallelizable]
    public void TestEmptyAndSingletonPairwise() {
        int[] emptyArray = [];
        int[] singletonArray = [1];
        var emptyEnumerable = System.Linq.Enumerable.Empty<int>();
        var singletonEnumerable = System.Linq.Enumerable.Range(0, 1);
        (int, int)[] expected = [];
        
        Assert.That(emptyArray.Pairwise(ValueTuple.Create), Is.EqualTo(expected));
        Assert.That(singletonArray.Pairwise(ValueTuple.Create), Is.EqualTo(expected));
        Assert.That(emptyEnumerable.Pairwise(ValueTuple.Create), Is.EqualTo(expected));
        Assert.That(singletonEnumerable.Pairwise(ValueTuple.Create), Is.EqualTo(expected));
    }

    [Test, Parallelizable]
    public void TestSkipAt() {
        int[] array = [1, 2, 3];
        int[] skipped = array.SkipAt(1).ToArray();
        int[] expected = [1, 3];
        Assert.That(skipped, Is.EqualTo(expected));
    }
}