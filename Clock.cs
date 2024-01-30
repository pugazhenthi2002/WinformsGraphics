using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDraft
{
    class Clock: UserControl
    {
        private double sinSec, cosSec;
        private double sinMin, cosMin;
        private double sinHr, cosHr;
        private double sinNum, cosNum;
        public Timer secMovement = new Timer();
        public int stepSec = 0, stepMin = 0, stepHr = 0, stepNumber=0;
        private Font f = new Font(new FontFamily("Arial"), 10);

        public Clock()
        {
            secMovement.Interval = 1000;
            secMovement.Tick += onSecMovement;
        }

        private void onSecMovement(object sender, EventArgs e)
        {
            stepSec += 6;
            
            this.Invalidate();

            if (stepSec % 360 == 0)
            {
                stepMin += 6;
                stepSec = 0;
            }

            if (stepMin % 360 == 0) 
            {
                stepHr += 30;
                stepMin = 0;
            }

            if(stepHr%360==0)
            {
                stepHr = 0;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Brush outerCircleBrush = new SolidBrush(Color.Black);
            Pen outerCirclePen = new Pen(Color.Gold, 2);

            Pen hourPen = new Pen(Color.Red, 3);
            Pen minPen = new Pen(Color.Brown, 2);
            Pen secPen = new Pen(Color.Gold, 1);

            g.FillEllipse(outerCircleBrush, new Rectangle(0, 0, Width, Height));
            g.DrawEllipse(outerCirclePen, new Rectangle(1, 1, Width-2, Height-2));

            sinSec = Math.Sin(stepSec * Math.PI / 180);
            cosSec = Math.Cos(stepSec * Math.PI / 180);

            sinMin = Math.Sin(stepMin * Math.PI / 180);
            cosMin = Math.Cos(stepMin * Math.PI / 180);

            sinHr = Math.Sin(stepHr * Math.PI / 180);
            cosHr = Math.Cos(stepHr * Math.PI / 180);

            g.DrawLine(secPen, new PointF(Width / 2, Height / 2), new PointF((float)((Width / 2) + (sinSec * (Width * 4 / 10))), (float)((Height / 2) - (cosSec * (Width * 4 / 10)))));
            g.DrawLine(minPen, new PointF(Width / 2, Height / 2), new PointF((float)((Width / 2) + (sinMin * (Width * 3 / 10))), (float)((Height / 2) - (cosMin * (Width * 3 / 10)))));
            g.DrawLine(hourPen, new PointF(Width / 2, Height / 2), new PointF((float)((Width / 2) + (sinHr * (Width * 2 / 10))), (float)((Height / 2) - (cosHr * (Width * 2 / 10)))));

            DrawNumbers(g);

            StringFormat s = new StringFormat();
            s.Alignment = StringAlignment.Center;
            s.LineAlignment = StringAlignment.Center;
            Font f1 = new Font(new FontFamily("Javanese Text"), Width/20, FontStyle.Italic);
            g.DrawString("SONATA", f1, new SolidBrush(Color.Silver), new RectangleF(0, 0, Width, Height/2), s);

            outerCircleBrush.Dispose(); outerCirclePen.Dispose(); hourPen.Dispose(); minPen.Dispose();  secPen.Dispose();   f1.Dispose();   s.Dispose();    
        }

        private void DrawNumbers(Graphics g)
        {
            stepNumber = 30;
            for (int ctr = 1; ctr <= 12; ctr++)
            {
                sinNum = Math.Sin(stepNumber * Math.PI / 180);
                cosNum = Math.Cos(stepNumber * Math.PI / 180);
                
                g.DrawString(ctr.ToString(), f, new SolidBrush(Color.White), new PointF((float)((Width / 2) + (sinNum * (Width *14/ 30)) - (f.Size/2)), (float)((Height / 2) - (cosNum * (Height * 14 / 30)) - (f.Size / 2))));
                stepNumber += 30;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height = Math.Max(Width, Height);
            f = new Font(new FontFamily("Arial"), Width / 20);
        }
        protected override void OnLoad(EventArgs e)
        {
            Width = Height = Math.Max(Width, Height);
            f = new Font(new FontFamily("Arial"), Width / 20);
            stepSec = 0;

            string s = DateTime.Now.ToString("HH:mm:ss tt");
            int hr = (s[0] - 48) * 10 + s[1] - 48, min = (s[3] - 48) * 10 + s[4] - 48, sec = (s[6] - 48) * 10 + s[7] - 48;
            stepHr = hr * 30;
            stepMin = min * 6;
            stepSec = sec * 6;
            secMovement.Start();
        }
    }
}
