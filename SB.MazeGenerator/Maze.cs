using System;
using System.Linq;
using System.Collections.Generic;

namespace SB.MazeGenerator
{
  public class Maze
  {
    public List<Cell> Cells;
    public Cell CurrentCell;
    public Stack<Cell> HistoryStack;


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

      this.HistoryStack = new Stack<Cell>();
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
      var nTop = new[] { c.X, c.Y - Cell.SIZE };
      var nRight = new[] { c.X + Cell.SIZE, c.Y };
      var nBott = new[] { c.X, c.Y + Cell.SIZE };
      var nLeft = new[] { c.X - Cell.SIZE, c.Y };

      var neighbors = new List<Cell>();

      if (nTop[0] >= 0 && nTop[0] < Scene.WIDTH && nTop[1] >= 0 && nTop[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == nTop[0] && n.Y == nTop[1]));

      if (nRight[0] >= 0 && nRight[0] < Scene.WIDTH && nRight[1] >= 0 && nRight[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == nRight[0] && n.Y == nRight[1]));

      if (nBott[0] >= 0 && nBott[0] < Scene.WIDTH && nBott[1] >= 0 && nBott[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == nBott[0] && n.Y == nBott[1]));

      if (nLeft[0] >= 0 && nLeft[0] < Scene.WIDTH && nLeft[1] >= 0 && nLeft[1] < Scene.HEIGHT)
        neighbors.AddRange(this.Cells.Where(n => !n.WasVisited && n.X == nLeft[0] && n.Y == nLeft[1]));

      return neighbors;
    }

  }
}
