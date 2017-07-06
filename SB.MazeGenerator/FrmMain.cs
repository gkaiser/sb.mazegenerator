using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace SB.MazeGenerator
{
  public partial class FrmMain : Form
  {
    private Scene Scene;
    private Timer RedrawTimer;

    public FrmMain()
    {
      InitializeComponent();

      this.Scene = new Scene();

      this.ClientSize = new Size(Scene.WIDTH, Scene.HEIGHT);

      this.RedrawTimer = new Timer();
      this.RedrawTimer.Interval = (int)((1 / Scene.FRAMES_PER_SEC) * 1000m);
      this.RedrawTimer.Tick += (s, ea) => this.Invalidate();
    }

    private void FrmMain_Load(object sender, EventArgs e)
    {
      this.Visible = true;
      Application.DoEvents();

      this.RedrawTimer.Start();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);

      var gfx = e.Graphics;

      this.Scene.Draw(gfx);

      if (this.Scene.Maze.Cells.Any(c => !c.WasVisited))
        this.Scene.Update();

      if (!this.DoubleBuffered) { gfx.Dispose(); }
    }

    private void FrmMain_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        Win32.ReleaseCapture();
        Win32.SendMessage(this.Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
      }
      if (e.Button == MouseButtons.Right)
        this.Close();
    }

  }
}
