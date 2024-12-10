using System.Diagnostics;
namespace AdventOfCode.Core;

public static class Matrix
{
    public static T[][] Transpose<T>(T[][] matrix) {
        ArgumentNullException.ThrowIfNull(matrix,nameof(matrix));
        if (matrix.Length == 0) {
            return matrix;
        }
        Debug.Assert(matrix.All(row => row.Length == matrix[0].Length));
        var result = new T[matrix[0].Length][];
        for (int i = 0; i < result.Length; i++) {
            result[i] = new T[matrix.Length];
        }
        for (int row = 0; row < matrix.Length; row++) {
            for (int col = 0; col < matrix[row].Length; col++) {
                result[col][row] = matrix[row][col];
            }
        }
        return result;
    }
    
}