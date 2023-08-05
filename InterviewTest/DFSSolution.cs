using System;
using System.Linq;

namespace InterviewTest
{
    public class DFSSolution : ISolution
    {
        private readonly int[][] _directions = 
        {
            new[] { -1, 0 }, 
            new[] { 1, 0 },  
            new[] { 0, -1 }, 
            new[] { 0, 1 }   
        };

        public int GetLargestIslandSize(int[][] grid)
        {
            if (IsInputParameterInvalid(grid))
            {
                throw new ArgumentException("grid parameter is invalid", nameof(grid));
            }
            
            var rowsCount = grid.Length;
            var columnsCount = grid[0].Length;
            var rowsElements = new int[rowsCount][];
            
            for (var i = 0; i < rowsCount; i++) 
            {
                rowsElements[i] = new int[columnsCount];
            }
            
            var maxIslandSize = 0;

            for (var i = 0; i < rowsCount; i++) 
            {
                for (var j = 0; j < columnsCount; j++)
                {
                    if (grid[i][j] != 1) 
                        continue;
                    
                    var currentIslandSize = ExcuteDFS(grid, rowsElements, i, j);
                    maxIslandSize = Math.Max(maxIslandSize, currentIslandSize);
                }
            }

            return maxIslandSize;
        }

        private static bool IsInputParameterInvalid(int[][] grid)
        {
            return grid == null || grid.Length == 0 || grid[0].Length == 0;
        }

        private int ExcuteDFS(int[][] grid, int[][] rowsElements, int rowIndex, int columnIndex)
        {
            var rows = grid.Length;
            var cols = grid[0].Length;

            if (rowIndex < 0 || rowIndex >= rows || columnIndex < 0 || columnIndex >= cols || grid[rowIndex][columnIndex] == 0 || rowsElements[rowIndex][columnIndex] == 1) 
            {
                return 0;
            }

            rowsElements[rowIndex][columnIndex] = 1;

            return 1 + (from dir in _directions let newRow = rowIndex + dir[0] let newCol = columnIndex + dir[1] select ExcuteDFS(grid, rowsElements, newRow, newCol)).Sum();
        }
    }
}