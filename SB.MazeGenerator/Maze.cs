using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.MazeGenerator
{
  public class Maze
  {
    public List<Cell> Cells;
    public Cell CurrentCell;
    private Stack<Cell> CellStack;

    public Maze(int horizCells, int vertCells)
    {
      this.Cells = new List<Cell>();

      for (int i = 0; i < horizCells; i++)
      {
        for(int j = 0; j < vertCells; j++)
        {
          this.Cells.Add(new Cell(i * Cell.SIZE, j * Cell.SIZE));
        }
      }

      this.CurrentCell = this.Cells[0];
      this.CurrentCell.WasVisited = true;

      this.CellStack = new Stack<Cell>();
    }

    public void BeginGeneration()
    {
    }

    public bool UnvisitedCellsExist
    {
      get { return this.Cells.Any(c => !c.WasVisited); }
    }

    public List<Cell> GetUnvisitedNeighbors(Cell c)
    {
      var n1Top = new[] { c.X, c.Y - Cell.SIZE };
      var n2Right = new[] { c.X + Cell.SIZE, c.Y };
      var n3Bott = new[] { c.X, c.Y + Cell.SIZE };
      var n4Left = new[] { c.X - Cell.SIZE, c.Y };

      var neighbors = new List<Cell>();

      if (n1Top[0] >= 0 && n1Top[0] < Scene.WIDTH && n1Top[1] >= 0 && n1Top[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == n1Top[0] && n.Y == n1Top[1]));

      if (n2Right[0] >= 0 && n2Right[0] < Scene.WIDTH && n2Right[1] >= 0 && n2Right[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == n2Right[0] && n.Y == n2Right[1]));

      if (n3Bott[0] >= 0 && n3Bott[0] < Scene.WIDTH && n3Bott[1] >= 0 && n3Bott[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == n3Bott[0] && n.Y == n3Bott[1]));

      if (n4Left[0] >= 0 && n4Left[0] < Scene.WIDTH && n4Left[1] >= 0 && n4Left[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == n4Left[0] && n.Y == n4Left[1]));

      return neighbors;
    }

  }
}
