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
    class LucidLogo: UserControl
    {
        private Point topPoint, leftPoint, rightPoint, bottomPoint;
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            DoubleBuffered = true;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Brush b1 = new SolidBrush(Color.White), b2 = new SolidBrush(Color.White);
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddLine(new Point(-1, -1), new Point(-1, leftPoint.Y + 1));
            path.AddLine(new Point(-1, leftPoint.Y + 1), new Point(topPoint.X + 1, -1));
            path.CloseFigure();

            path.AddLine(new Point(Width+1, -1), new Point(topPoint.X - 1, -1));
            path.AddLine(new Point(topPoint.X - 1, -1), new Point(Width + 1, rightPoint.Y + 1));
            path.CloseFigure();

            path.AddArc(new Rectangle(-Width * 3 / 2 + Width/10, Height * 8 / 20 + Height/50, Width * 2, Height * 2), 225, 180);
            path.CloseFigure();

            path.AddArc(new Rectangle(Width/2 - Width/10, Height * 8 / 20 + Height/50, Width * 2, Height * 2), 135, 180);
            path.CloseFigure();

            //path.AddArc(new Rectangle(Width/2, Height/2, Width / 2, Height / 2), 135, 180);
            path.CloseAllFigures();
            //g.DrawArc(new Pen(Color.White), new Rectangle(0, Height / 2, Width / 2, Height / 2), 225, 180);
            g.FillPath(b1, path);
            g.FillEllipse(b1, new Rectangle(Width * 16 / 28, Height * 10 / 28, Width / 28, Height / 28));

            Point[] leftTri = new Point[] { new Point(Width * 33 / 56, Height * 20 / 56), new Point(Width * 33 / 56 - Width/2, Height * 21 / 56), new Point(Width * 33 / 56, Height * 22 / 56) };
            Point[] topTri = new Point[] { new Point(Width * 32 / 56, Height * 21 / 56), new Point(Width * 33 / 56, Height * 21 / 56 - Height/2), new Point(Width * 34 / 56, Height * 21 / 56) };
            Point[] rightTri = new Point[] { new Point(Width * 33 / 56, Height * 20 / 56), new Point(Width * 33 / 56 + Width/2, Height * 21 / 56), new Point(Width * 33 / 56, Height * 22 / 56) };
            Point[] bottomTri = new Point[] { new Point(Width * 32 / 56, Height * 21 / 56), new Point(Width * 33 / 56, Height * 21 / 56 + Height / 2), new Point(Width * 34 / 56, Height * 21 / 56) };

            Point[] leftTopTri = new Point[] { new Point(Width * 32 / 56, Height * 21 / 56), new Point(Width * 33 / 56 - Width/2, Height * 21 / 56 - Height/2), new Point(Width * 33 / 56, Height * 20 / 56) };
            Point[] rightTopTri = new Point[] { new Point(Width * 34 / 56, Height * 21 / 56), new Point(Width * 34 / 56 + Width/2, Height * 21 / 56 - Height/2), new Point(Width * 33 / 56, Height * 20 / 56) };
            Point[] leftBottomTri = new Point[] { new Point(Width * 32 / 56, Height * 21 / 56), new Point(Width * 32 / 56 - Width/2, Height * 21 / 56 + Height/2), new Point(Width * 33 / 56, Height * 22 / 56) };
            Point[] rightBottomTri = new Point[] { new Point(Width * 33 / 56, Height * 22 / 56), new Point(Width * 33 / 56 + Width / 2, Height * 22 / 56 + Height / 2), new Point(Width * 34 / 56, Height * 21 / 56) };

            g.FillPolygon(b1, leftTri);
            g.FillPolygon(b1, topTri);
            g.FillPolygon(b1, rightTri);
            g.FillPolygon(b1, bottomTri);

            g.FillPolygon(b1, leftTopTri);
            g.FillPolygon(b1, rightTopTri);
            g.FillPolygon(b1, leftBottomTri);
            g.FillPolygon(b1, rightBottomTri);

            b1.Dispose();
        }

        protected override void OnResize(EventArgs e)
        {
            topPoint = new Point(Width / 2, 0);
            leftPoint = new Point(0, Height / 2);
            rightPoint = new Point(Width, Height / 2);
            bottomPoint = new Point(Width / 2, Height);

            Width = Height = Math.Max(Width, Height);
            this.Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            topPoint = new Point(Width / 2, 0);
            leftPoint = new Point(0, Height / 2);
            rightPoint = new Point(Width, Height / 2);
            bottomPoint = new Point(Width / 2, Height);
            BackColor = Color.DarkBlue;
        }
    }
}
