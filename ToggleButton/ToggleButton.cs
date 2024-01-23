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
    class ToggleButton: UserControl
    {
        private bool isTurnedOn = false;
        private ToggleTimer ToggleT;
        private int toggleButtonX = 0;

        public ToggleButton()
        {
            ToggleT = new ToggleTimer();
            ToggleT.Interval = 1;
            ToggleT.ToggleButtonMoved += OnToggleButtonMove;
        }

        private void OnToggleButtonMove(object sender, int movement)
        {
            toggleButtonX += movement;
            if((toggleButtonX < Height * 2 / 20) || (toggleButtonX > Width * 3 / 4))
            {
                ToggleT.Stop();
            }
            else
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            DoubleBuffered = true;
            Rectangle rec1 = new Rectangle(0, 0, Width / 4, Width / 4);
            Rectangle rec2 = new Rectangle(Width * 3 / 4, 0, Width / 4, Width / 4);

            GraphicsPath path1 = new GraphicsPath();
            path1.StartFigure();
            path1.AddArc(rec1, 90, 180);
            path1.AddArc(rec2, 270, 180);
            path1.CloseFigure();

            g.FillPath(new SolidBrush(Color.Black), path1);

            rec1 = new Rectangle(Height / 20, Height / 20, Width / 4 - (Height * 2 / 20), Width / 4 - (Height * 2 / 20));
            rec2 = new Rectangle(Width * 3 / 4, Height / 20, Width / 4 - (Height / 20), Width / 4 - (Height * 2 / 20));

            GraphicsPath path2 = new GraphicsPath();
            path2.StartFigure();
            path2.AddArc(rec1, 90, 180);
            path2.AddArc(rec2, 270, 180);
            path2.CloseFigure();

            Rectangle circleButton = new Rectangle(toggleButtonX, Height * 2 / 20, Width / 4 - (Height * 2 / 20), Width / 4 - (Height * 4 / 20));
            Color c = Color.FromArgb(100, Color.Blue);
            if (!isTurnedOn)
            {
                g.FillPath(new SolidBrush(Color.Red), path2);
                g.FillEllipse(new SolidBrush(Color.White), circleButton);
                g.DrawEllipse(new Pen(c, 2), circleButton);
            }
            else
            {
                g.FillPath(new SolidBrush(Color.Green), path2);
                g.FillEllipse(new SolidBrush(Color.White), circleButton);
                g.DrawEllipse(new Pen(c, 2), circleButton);
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (isTurnedOn)
            {
                ToggleT.Start(-Height/10);
            }
            else
            {
                ToggleT.Start(Height/10);
            }

            isTurnedOn = !isTurnedOn;
        }

        protected override void OnResize(EventArgs e)
        {
            Height = Width / 4;
        }

        protected override void OnLoad(EventArgs e)
        {
            Height = Width / 4;
            toggleButtonX = Height * 2 / 20;
        }
    }
}
