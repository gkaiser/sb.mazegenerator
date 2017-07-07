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

    public void RemoveWallWithNeighbor(Cell n)
    {
      var xDiff = this.X - n.X;
      if (xDiff > 0)
      {
        this.IsLeftWalled = false;
        n.IsRightWalled = false;
      }
      else if (xDiff < 0)
      {
        this.IsRightWalled = false;
        n.IsLeftWalled = false;
      }

      var yDiff = this.Y - n.Y;
      if (yDiff > 0)
      {
        this.IsTopWalled = false;
        n.IsBottomWalled = false;
      }
      else if (yDiff < 0)
      {
        this.IsBottomWalled = false;
        n.IsTopWalled = false;
      }
    }

  }
}
