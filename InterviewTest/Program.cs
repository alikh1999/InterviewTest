using System;

namespace InterviewTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] grid =
            {
                new[] { 1, 1, 0, 0, 1 },
                new[] { 1, 1, 0, 0, 1 },
                new[] { 0, 1, 1, 1, 1 },
                new[] { 0, 0, 0, 0, 0 },
                new[] { 1, 0, 1, 0, 1 }
            };

            ISolution solution = new DFSSolution();
            var largestIslandSize = solution.GetLargestIslandSize(grid);
            Console.WriteLine(largestIslandSize);
        }
    }
}