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
      this.Scene.Update();

      if (!this.DoubleBuffered) { gfx.Dispose(); }

      if (!this.Scene.Maze.UnvisitedCellsExist && this.RedrawTimer.Enabled)
        this.RedrawTimer.Stop();
    }

    private void FrmMain_MouseDown(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left && e.Clicks == 1)
      {
        this.RedrawTimer.Stop();
        //Win32.ReleaseCapture();
        //Win32.SendMessage(this.Handle, Win32.WM_NCLBUTTONDOWN, Win32.HT_CAPTION, 0);
      }
      else if (e.Button == MouseButtons.Left && e.Clicks == 2)
        this.Close();
    }

  }
}
