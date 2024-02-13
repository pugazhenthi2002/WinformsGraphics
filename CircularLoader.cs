using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDraft
{
    class CircularLoader: Control
    {
        public CircularLoader()
        {
            loadTimer = new Timer();
            loadTimer.Interval = 1;
            loadTimer.Tick += OnLoadingAnimation;
            startAngle1 = 270;
            startAngle2 = 90;
            DoubleBuffered = true;
            loadTimer.Start();
        }

        private void OnLoadingAnimation(object sender, EventArgs e)
        {
            if(startAngle1%360==0)
            {
                startAngle1 = 0;
            }

            if(startAngle2%360==0)
            {
                startAngle2 = 0;
            }

            startAngle1 += 2;
            startAngle2 += 2;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Brush b1 = new SolidBrush(Color.AliceBlue);
            Brush b2 = new SolidBrush(Color.White);
            Brush b3 = new SolidBrush(Color.Blue);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.FillEllipse(b1, new Rectangle(0, 0, Width, Height));
            g.FillPie(b3, new Rectangle(0, 0, Width, Height), startAngle1, 90);
            g.FillPie(b3, new Rectangle(0, 0, Width, Height), startAngle2, 90);
            g.FillEllipse(b2, new Rectangle(Width / 10, Height / 10, Width * 8 / 10, Height * 8 / 10));

            b1.Dispose();
            b2.Dispose();
            b3.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height = Math.Min(Width, Height);
        }

        private Timer loadTimer;
        private int startAngle1, startAngle2;
    }
}
