using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SudokuSolver
{
    public class SudokuHelper
    {
        //public List<List<int>> grid { get; set; }

        public bool IsPossible(List<List<int>> grid, int x, int y, int n)
        {
            for (int i = 0; i < 9; i++)
            {
                //check x axis
                if (grid[y][i] == n)
                    return false;
                //check y axis
                if (grid[i][x] == n)
                    return false;
            }

            //check square
            int startX = (x / 3) * 3;
            int startY = (y / 3) * 3;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (grid[startY + i][startX + j] == n)
                        return false;
                }
            }
            return true;
        }

        public void PrintGrid(List<List<int>> grid)
        {
            foreach (List<int> line in grid)
                Console.WriteLine($"{string.Join(" ", line.ToArray())} ");
            Console.WriteLine();
        }

        public void Solve(List<List<int>> grid)
        {
            for (int y = 0; y < 9; y++)
            {
                for (int x = 0; x < 9; x++)
                {
                    if (grid[y][x] == 0)
                    {
                        for (int n = 1; n < 10; n++)
                        {
                            if (IsPossible(grid, x, y, n))
                            {
                                grid[y][x] = n;
                                //try to populate next
                                Solve(grid);
                                //backtracking, if first possible value did not yield finnishing result
                                grid[y][x] = 0;
                            }
                        }
                        //all values tried
                        return;
                    }
                }
            }
            PrintGrid(grid);
        }
    }
}
