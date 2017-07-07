using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SB.MazeGenerator
{
  public class Scene
  {
    public const decimal FRAMES_PER_SEC = 60m;
    public const int WIDTH = 600;
    public const int HEIGHT = 600;

    public Maze Maze;
    public Random RandGen = new Random();

    public Scene()
    {
      this.Maze = new Maze(Scene.WIDTH / Cell.SIZE, Scene.HEIGHT / Cell.SIZE);
    }

    public void Draw(Graphics gfx)
    {
      gfx.FillRectangle(Brushes.Black, 0, 0, Scene.WIDTH, Scene.HEIGHT);

      foreach (var c in this.Maze.Cells)
      {
        if (c == this.Maze.CurrentCell)
          gfx.FillRectangle(Brushes.White, c.X, c.Y, Cell.SIZE, Cell.SIZE);
        else if (c.WasVisited)
          gfx.FillRectangle(Brushes.Purple, c.X, c.Y, Cell.SIZE, Cell.SIZE);

        if (c.IsTopWalled)
          gfx.DrawLine(Pens.White, c.X, c.Y, c.X + Cell.SIZE, c.Y);
        if (c.IsBottomWalled)
          gfx.DrawLine(Pens.White, c.X, c.Y + Cell.SIZE, c.X + Cell.SIZE, c.Y + Cell.SIZE);
        if (c.IsLeftWalled)
          gfx.DrawLine(Pens.White, c.X, c.Y, c.X, c.Y + Cell.SIZE);
        if (c.IsRightWalled)
          gfx.DrawLine(Pens.White, c.X + Cell.SIZE, c.Y, c.X + Cell.SIZE, c.Y + Cell.SIZE);
      }
    }

    public void Update()
    {
      var nbors = this.Maze.GetUnvisitedNeighbors(this.Maze.CurrentCell);
      if (nbors.Count == 0)
      {
        if (!this.Maze.UnvisitedCellsExist || this.Maze.HistoryStack.Count == 0)
          return;

        this.Maze.CurrentCell = this.Maze.HistoryStack.Pop();

        return;
      }

      var idx = this.RandGen.Next(0, nbors.Count);
      var next = nbors[idx];

      next.WasVisited = true;

      this.Maze.HistoryStack.Push(this.Maze.CurrentCell);

      Cell.RemoveWalls(this.Maze.CurrentCell, next);

      this.Maze.CurrentCell = next;
    }

  }
}
