using System;

namespace Number_of_Closed_Islands
{
  class Program
  {
    static void Main(string[] args)
    {
      var grid = new int[][] { new int[] { 1, 1, 1 }, new int[] { 1, 0, 1 }, new int[] { 1, 1, 1 } };
      Solution s = new Solution();
      var answer = s.ClosedIsland(grid);
      Console.WriteLine(answer);
    }
  }

  public class Solution
  {
    public int ClosedIsland(int[][] grid)
    {
      // need to ignore the lands appeared in the borders of the grid
      // will be using -1 to mark a land as visited
      int result = 0;
      int r = grid.Length; int c = grid[0].Length;
      for (int i = 1; i < r - 1; i++)
      {
        for (int j = 1; j < c - 1; j++)
        {
          if (grid[i][j] == 0 && IsClosed(i, j, r, c, grid))
          {
            result++;
          }
        }
      }

      return result;
    }

    private bool IsClosed(int i, int j, int r, int c, int[][] grid)
    {
      // if visited or water
      if (grid[i][j] == -1 || grid[i][j] == 1) return true;
      // first check it is on the boundary
      // base condition
      if (IsOnBoundary(i, j, r, c)) return false;

      grid[i][j] = -1;
      bool left = IsClosed(i, j - 1, r, c, grid);
      bool right = IsClosed(i, j + 1, r, c, grid);
      bool up = IsClosed(i - 1, j, r, c, grid);
      bool down = IsClosed(i + 1, j, r, c, grid);

      return left && right && up && down;
    }

    private bool IsOnBoundary(int i, int j, int r, int c)
    {
      return i == 0 || j == 0 || i == r - 1 || j == c - 1;
    }
  }
}
