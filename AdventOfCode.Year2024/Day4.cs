using System.Diagnostics;
using System.Text.RegularExpressions;
using AdventOfCode.Core;

namespace AdventOfCode.Year2024;

public static class Day4
{


    private static T[] Diagonal<T>(T[][] matrix, (int row, int col) startIndex
                                 , Func<(int, int), (int, int)> nextIndex) {
        var (startRow, startCol) = startIndex;
        Debug.Assert(matrix is not null && matrix.All(row => row.Length > 0));
        Debug.Assert(startRow >= 0 && startRow < matrix.Length);
        Debug.Assert(startCol >= 0 && startCol < matrix[0].Length);
        Debug.Assert(matrix.All(row => row.Length == matrix[0].Length));
        var result = new List<T>();
        int rows = matrix.Length, cols = matrix[0].Length;
        int row = startRow, col = startCol;
        while (row < rows && col < cols && row >= 0 && col >= 0) {
            result.Add(matrix[row][col]);
            (row, col) = nextIndex((row, col));
        }
        return result.ToArray();
    }

    public static int Part1(string input) {
        var matrix = InputParser.ParseCharMatrix(input);
        var topEdge = matrix[0].Indices().Select(col => (0, col)).ToArray();
        var bottomEdge = matrix[0].Indices().Select(col => (matrix.Length - 1, col)).ToArray();
        var leftEdge = matrix.Indices().Select(row => (row, 0)).ToArray();

        (int, int) MoveDownRight((int row, int col) index) => (index.row + 1, index.col + 1);
        (int, int) MoveTopRight((int row, int col) index) => (index.row - 1, index.col + 1);
        
        var leftDown = leftEdge.Select(start => Diagonal(matrix, start, MoveDownRight)).ToArray();
        var leftUp = leftEdge.Select(start => Diagonal(matrix, start, MoveTopRight)).ToArray();
        var left = leftDown.Concat(leftUp).ToArray();
        var top = topEdge.Select(start => Diagonal(matrix, start, MoveDownRight)).ToArray();
        var bottom = bottomEdge.Select(start => Diagonal(matrix, start, MoveTopRight)).ToArray();
        var diagonals = left.Concat(top).Concat(bottom);
        var rows = matrix; 
        var cols = Matrix.Transpose(matrix);
        var all = rows.Concat(cols).Concat(diagonals).ToArray();
        var count = 0;
        foreach (var collection in all) {
            count += Regex.Count(collection, "XMAS|SAMX");
        }
        return count;
    }
    
}