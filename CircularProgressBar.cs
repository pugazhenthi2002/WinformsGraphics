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
    class CircularProgressBar: UserControl
    {
        private int outerRadius = 0, innerCircleLocation = 0, percentage = 0, loadingCount=0;
        private float bendAngle = 0, animationBendAngle = 0;
        public bool isCompleted = false;
        public Timer CircularProgressTimer = new Timer();
        public Timer LoadingAnimationTimer = new Timer();

        public CircularProgressBar()
        {
            CircularProgressTimer.Interval = 60;
            CircularProgressTimer.Tick += OnPercentageChange;

            LoadingAnimationTimer.Interval = 30;
            LoadingAnimationTimer.Tick += OnLoadingAnimation;
        }

        private void OnLoadingAnimation(object sender, EventArgs e)
        {
            for (int ctr = 0; ctr <= percentage; ctr++)
            {
                loadingCount = ctr;
                this.Invalidate();
            }
        }

        private void OnPercentageChange(object sender, EventArgs e)
        {
            percentage++;
            Invalidate();

            if (percentage == 100)
            {
                isCompleted = true;
                CircularProgressTimer.Stop();
                LoadingAnimationTimer.Stop();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            bendAngle = percentage * 360 / 100;
            animationBendAngle = loadingCount * 360 / 100;
            outerRadius = Height;
            innerCircleLocation = outerRadius / 10;


            DoubleBuffered = true;
            Color color = Color.FromArgb(115, Color.Gray);
            Color animationColor = Color.FromArgb(50, Color.White);
            Brush innerBrush = new SolidBrush(Color.White);
            Brush outerBrush = new SolidBrush(color);
            Font f = new Font(new FontFamily("Arial"), 20);
            StringFormat s = new StringFormat();
            s.Alignment = StringAlignment.Center;
            s.LineAlignment = StringAlignment.Center;

            Pen animationPen = new Pen(animationColor, innerCircleLocation);
            animationPen.StartCap = animationPen.EndCap = LineCap.Round;

            Pen pen = new Pen(Color.Green, innerCircleLocation);
            pen.StartCap = pen.EndCap = LineCap.Round;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillEllipse(outerBrush, 0, 0, outerRadius, outerRadius);  //outerCircle
            g.FillEllipse(innerBrush, innerCircleLocation, innerCircleLocation, outerRadius - (innerCircleLocation * 2), outerRadius - (innerCircleLocation * 2));  //innerCircle
            g.DrawArc(pen, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, 270, bendAngle);
            g.DrawArc(animationPen, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, 270, animationBendAngle);

            g.DrawString(percentage + "%", f, new SolidBrush(Color.Red), new RectangleF(0, 0, Width, Height), s);

            

            innerBrush.Dispose();   outerBrush.Dispose();   f.Dispose();    s.Dispose();    pen.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height = Math.Max(Width, Height);
            Margin = new Padding(0);
        }
    }
}
