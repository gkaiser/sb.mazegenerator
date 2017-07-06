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
    private Cell CurrentCell;

    public Maze(int horizCells, int vertCells)
    {
      this.Cells = new List<Cell>();

      for (int i = 0; i < horizCells; i++)
      {
        for(int j = 0; j < vertCells; j++)
        {
          this.Cells.Add(new Cell(i * Cell.WIDTH, j * Cell.HEIGHT));
        }
      }

      this.CurrentCell = this.Cells[0];
      this.CurrentCell.WasVisited = true;
    }

    public void BeginGeneration()
    {
    }

  }
}
