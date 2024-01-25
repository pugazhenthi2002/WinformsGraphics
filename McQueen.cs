using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDraft
{
    public class McQueen: UserControl
    {
        public McQueen()
        {
            BackColor = Color.Transparent;
            DoubleBuffered = true;
        }

        private GraphicsPath GetFigurePath()
        {
            
            GraphicsPath path = new GraphicsPath();
            

            return path;
        }
        private const int CircleRadius = 50;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
           
            int x = this.Width / 5, y = this.Height * 2 / 5, stepWidth = this.Width / 5, remainingWidth = stepWidth - (this.Height * 15 / 50);

            Rectangle r1 = new Rectangle(0, this.Height * 2 / 5, this.Width / 5, this.Height * 2 / 5);
            Rectangle r2 = new Rectangle(this.Width * 4 / 5, this.Height * 2 / 5, this.Width / 5, this.Height * 2 / 5);

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(r1, 90, 180);
            path.AddArc(r2, 270, 180);
            path.CloseFigure();

            Rectangle r3 = new Rectangle(this.Width * 46 / 50, this.Height * 2 / 5, this.Width * 4 / 50, 2 * this.Height * 4 / 50);

            Point[] points = new Point[] { new Point(x, y), new Point(x = x + (this.Width / 5), y), new Point(x, y - (this.Height / 5) - (this.Height * 2 / 50)), new Point(x - (this.Width / 5) + (this.Width / 50), y - (this.Height / 5) - (this.Height * 2 / 50)) };
            g.DrawPolygon(new Pen(Color.Gray, 3), points);

            points = new Point[] { new Point(x, y), new Point(x = x + (this.Width / 5), y), new Point(x, y - (this.Height / 5) - (this.Height * 2 / 50)), new Point(x - (this.Width / 5), y - (this.Height / 5) - (this.Height * 2 / 50)) };
            g.DrawPolygon(new Pen(Color.Gray, 3), points);

            points = new Point[] { new Point(x, y), new Point(x = x + (this.Width / 5), y), new Point(x - (this.Width / 50), y - (this.Height / 5) - (this.Height * 2 / 50)), new Point(x - (this.Width / 5), y - (this.Height / 5) - (this.Height * 2 / 50)) };
            g.DrawPolygon(new Pen(Color.Gray, 3), points);

            points = new Point[] { new Point(this.Width * 9 / 50, this.Height * 4 / 5), new Point(this.Width * 8 / 50, this.Height * 42 / 50), new Point(this.Width * 3 / 50, this.Height * 42 / 50), new Point(this.Width * 3 / 50, this.Height * 44 / 50), new Point(this.Width * 9 / 50, this.Height * 44 / 50), new Point(this.Width * 10 / 50, this.Height * 4 / 5) };

            g.DrawPolygon(new Pen(Color.Black, 2), points);
            g.FillPath(new SolidBrush(Color.Blue), path);
            g.FillEllipse(new SolidBrush(Color.Yellow), r3);
            g.FillEllipse(new SolidBrush(Color.Black), this.Width / 5, this.Height * 35 / 50, this.Height * 15 / 50, this.Height * 15 / 50);
            g.DrawEllipse(new Pen(Color.White), (this.Width / 5) + 3, (this.Height * 35 / 50) + 3, (this.Height * 15 / 50) - 6, (this.Height * 15 / 50) - 6);
            g.FillEllipse(new SolidBrush(Color.Black), (this.Width * 3 / 5) + remainingWidth, this.Height * 35 / 50, this.Height * 15 / 50, this.Height * 15 / 50);
            g.DrawEllipse(new Pen(Color.White), ((this.Width * 3 / 5) + remainingWidth) + 3, (this.Height * 35 / 50) + 3, (this.Height * 15 / 50) - 6, (this.Height * 15 / 50) - 6);
            g.DrawLine(new Pen(Color.Blue), 0, this.Height * 41 / 50, this.Width * 1 / 50, this.Height * 41 / 50);
            g.DrawLine(new Pen(Color.Orange), 0, this.Height * 42 / 50, this.Width * 1 / 50, this.Height * 42 / 50);
            g.DrawLine(new Pen(Color.Blue), 0, this.Height * 43 / 50, this.Width * 1 / 50, this.Height * 43 / 50);
            g.DrawLine(new Pen(Color.Red), 0, this.Height * 44 / 50, this.Width * 1 / 50, this.Height * 44 / 50);

        }

        protected override void OnResize(EventArgs e)
        {
            this.Invalidate();
        }
    }
}
