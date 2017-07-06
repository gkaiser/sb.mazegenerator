using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.MazeGenerator
{
  public class Cell
  {
    public const int SIZE = 60;
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

    

  }
}
