using NUnit.Framework.Legacy;

namespace AdventOfCode.Core.Tests;

public class MatrixTests
{
    [Test, Parallelizable]
    public void TestTransposeEmptyMatrix() {
        int[][] emptyMatrix = [];
        Assert.That(Matrix.Transpose(emptyMatrix), Is.EqualTo(emptyMatrix));
    }
    
    [Test, Parallelizable]
    public void TestTransposeNonEmptyMatrix() {
        int[][] nonEmptyMatrix = [[1,2,3],[4,5,6]];
        int[][] transposed = Matrix.Transpose(nonEmptyMatrix);
        int[][] expected = [[1,4],[2,5],[3,6]];
        Assert.That(transposed, Is.EqualTo(expected));
    }
}