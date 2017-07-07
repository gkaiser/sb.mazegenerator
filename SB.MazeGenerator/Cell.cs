using System;

namespace SB.MazeGenerator
{
  public class Cell
  {
    public const int SIZE = 10;
    public int X;
    public int Y;

    public bool WasVisited = false;
    public bool IsTopWalled = true;
    public bool IsBottomWalled = true;
    public bool IsLeftWalled = true;
    public bool IsRightWalled = true;

    public Cell(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public static void RemoveWalls(Cell c1, Cell c2)
    {
      var xDiff = c1.X - c2.X;
      if (xDiff > 0)
      {
        c1.IsLeftWalled = false;
        c2.IsRightWalled = false;
      }
      else if (xDiff < 0)
      {
        c1.IsRightWalled = false;
        c2.IsLeftWalled = false;
      }

      var yDiff = c1.Y - c2.Y;
      if (yDiff > 0)
      {
        c1.IsTopWalled = false;
        c2.IsBottomWalled = false;
      }
      else if (yDiff < 0)
      {
        c1.IsBottomWalled = false;
        c2.IsTopWalled = false;
      }
    }

  }
}
