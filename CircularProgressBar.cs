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
        private float bendAngle = 0, animationBendAngle = 270;
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
            if(loadingCount>percentage)
            {
                loadingCount = 0;
            }
            else
            {
                loadingCount++;
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
            animationBendAngle = (loadingCount * 360 / 100) + 270;
            outerRadius = Height;
            innerCircleLocation = outerRadius / 10;

            DoubleBuffered = true;
            Color color = Color.FromArgb(115, Color.Gray);

            

            Brush innerBrush = new SolidBrush(Color.White);
            Brush outerBrush = new SolidBrush(color);

            Font f = new Font(new FontFamily("Arial"), 20);

            StringFormat s = new StringFormat();
            s.Alignment = StringAlignment.Center;
            s.LineAlignment = StringAlignment.Center;

            Pen pen = new Pen(Color.Green, innerCircleLocation);
            pen.StartCap = pen.EndCap = LineCap.Round;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            g.FillEllipse(outerBrush, 0, 0, outerRadius, outerRadius);  //outerCircle
            g.FillEllipse(innerBrush, innerCircleLocation, innerCircleLocation, outerRadius - (innerCircleLocation * 2), outerRadius - (innerCircleLocation * 2));  //innerCircle
            g.DrawArc(pen, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, 270, bendAngle);


            LoadingAnimation(g);

            g.DrawString(percentage + "%", f, new SolidBrush(Color.Red), new RectangleF(0, 0, Width, Height), s);

            innerBrush.Dispose();   outerBrush.Dispose();   f.Dispose();    s.Dispose();    pen.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height = Math.Max(Width, Height);
            Margin = new Padding(0);
        }

        private void LoadingAnimation(Graphics g)
        {
            Color animationColorL1 = Color.FromArgb(20, Color.White);
            Color animationColorL2 = Color.FromArgb(35, Color.White);
            Color animationColorL3 = Color.FromArgb(50, Color.White);
            Color animationColorM = Color.FromArgb(80, Color.White);
            Color animationColorR3 = Color.FromArgb(50, Color.White);
            Color animationColorR2 = Color.FromArgb(35, Color.White);
            Color animationColorR1 = Color.FromArgb(20, Color.White);

            Pen animationPenLeft1 = new Pen(animationColorL1, innerCircleLocation);
            Pen animationPenLeft2 = new Pen(animationColorL2, innerCircleLocation);
            Pen animationPenLeft3 = new Pen(animationColorL3, innerCircleLocation);
            Pen animationPenRight3 = new Pen(animationColorR3, innerCircleLocation);
            Pen animationPenRight2 = new Pen(animationColorR2, innerCircleLocation);
            Pen animationPenRight1 = new Pen(animationColorR1, innerCircleLocation);
            Pen animationPenMiddle = new Pen(animationColorM, innerCircleLocation);

            if (bendAngle > 2 && !isCompleted && animationBendAngle + 25 < bendAngle + 270)
            {
                g.DrawArc(animationPenLeft1, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, animationBendAngle, 3);
                g.DrawArc(animationPenLeft2, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, animationBendAngle + 3, 3);
                g.DrawArc(animationPenLeft3, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, animationBendAngle + 6, 4);
                g.DrawArc(animationPenMiddle, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, animationBendAngle + 10, 5);
                g.DrawArc(animationPenRight3, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, animationBendAngle + 15, 4);
                g.DrawArc(animationPenRight2, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, animationBendAngle + 19, 3);
                g.DrawArc(animationPenRight1, innerCircleLocation / 2, innerCircleLocation / 2, outerRadius - innerCircleLocation, outerRadius - innerCircleLocation, animationBendAngle + 22, 3);
            }

            animationPenLeft1.Dispose();
            animationPenLeft2.Dispose();
            animationPenLeft3.Dispose();
            animationPenRight1.Dispose();
            animationPenRight2.Dispose();
            animationPenRight3.Dispose();
            animationPenMiddle.Dispose();
        }
    }   

}
