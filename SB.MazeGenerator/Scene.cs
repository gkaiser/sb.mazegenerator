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
    public const decimal FRAMES_PER_SEC = 15m;
    public const int WIDTH = 600;
    public const int HEIGHT = 600;

    public Maze Maze;
    public Random RandGen = new Random((int)DateTime.Now.Subtract(DateTime.Today).TotalSeconds);

    public Scene()
    {
      this.Maze = new Maze(Scene.WIDTH / Cell.SIZE, Scene.HEIGHT / Cell.SIZE);
    }

    public void Draw(Graphics gfx)
    {
      gfx.FillRectangle(Brushes.Black, 0, 0, Scene.WIDTH, Scene.HEIGHT);

      foreach (var c in this.Maze.Cells)
      {
        if (c.WasVisited)
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
        return;

      var idx = this.RandGen.Next(0, nbors.Count - 1);
      Console.WriteLine($"0 <==> {idx} <==> {nbors.Count - 1}");

      var next = nbors[idx];

      next.WasVisited = true;
      this.Maze.CurrentCell = next;
    }

  }
}
