using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SB.MazeGenerator
{
  public class Scene
  {
    public static Random RandGen = new Random((int)DateTime.Now.Subtract(DateTime.Today).TotalSeconds);
    public const decimal FRAMES_PER_SEC = 15m;
    public const int WIDTH = 600;
    public const int HEIGHT = 600;

    public Maze Maze;

    public Scene()
    {
      this.Maze = new Maze(Scene.WIDTH / Cell.WIDTH, Scene.HEIGHT / Cell.HEIGHT);
    }

    public void Draw(Graphics gfx)
    {
      gfx.FillRectangle(Brushes.Black, 0, 0, Scene.WIDTH, Scene.HEIGHT);

      foreach (var c in this.Maze.Cells)
      {
        if (c.WasVisited)
          gfx.FillRectangle(Brushes.Purple, c.X, c.Y, Cell.WIDTH, Cell.HEIGHT);

        if (c.IsTopWalled)
          gfx.DrawLine(Pens.White, c.X, c.Y, c.X + Cell.WIDTH, c.Y);
        if (c.IsBottomWalled)
          gfx.DrawLine(Pens.White, c.X, c.Y + Cell.HEIGHT, c.X + Cell.WIDTH, c.Y + Cell.HEIGHT);
        if (c.IsLeftWalled)
          gfx.DrawLine(Pens.White, c.X, c.Y, c.X, c.Y + Cell.HEIGHT);
        if (c.IsRightWalled)
          gfx.DrawLine(Pens.White, c.X + Cell.WIDTH, c.Y, c.X + Cell.WIDTH, c.Y + Cell.HEIGHT);
      }

    }

    public void Update()
    {
      //if (this.Maze.) 
    }

  }
}
