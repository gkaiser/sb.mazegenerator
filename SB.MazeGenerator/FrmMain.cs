using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }

  }
}
