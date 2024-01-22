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
    class RippleButton: Button
    {
        private int rippleSize;
        private List<Ripple> Clicks= new List<Ripple>();
        private List<Timer> Timers= new List<Timer>();
        private Timer t = new Timer();
        private int Count = 0;
        public RippleButton()
        {
            this.MouseDown += RippleButton_MouseDown;
            this.Paint += RippleButton_Paint;
            
        }

        private void RippleButton_MouseDown(object sender, MouseEventArgs e)
        {
            Clicks.Add(new WindowsFormsDraft.Ripple { X = e.X, Y = e.Y, Size = 0 });

           if(Count==0)
            {
                Count++;
                t = new Timer();
                t.Interval = 30;
                t.Tick += RippleTimer_Tick;
                t.Start();
            }
            
        }

        private void RippleTimer_Tick(object sender, EventArgs e)
        {
            for (int Iter = 0; Iter < Clicks.Count; Iter++)
            {
                Clicks[Iter].Size += 5;
            }

            this.Invalidate();
            this.DoubleBuffered = true;

            for (int Iter = 0; Iter < Clicks.Count; Iter++)
            {

                if (Clicks[Iter].Size > (Width + Height))
                {
                    if (Clicks.Count == 1)
                    {
                        t.Stop();
                        Count = 0;
                    }
                    rippleSize = Clicks[Iter].Size = 0;
                    Clicks.RemoveAt(Iter);
                }
            }
                
        }

        private void RippleButton_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            foreach (var Iter in Clicks)
            {
                if (Iter.Size > 0)
                {
                    
                    Color nonIntersectingColor = Color.FromArgb(40, Color.AliceBlue);
                    var b = new SolidBrush(nonIntersectingColor);
                    g.FillEllipse(b, Iter.X - (Iter.Size), Iter.Y - (Iter.Size), 2 * Iter.Size, 2 * Iter.Size);
                    
                    
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    
                    b.Dispose();
                }
            }
            //string buttonText = "Pugazh";
            //Font f = new Font(new FontFamily("Arial"), 20);
            //float singleLetterPixelX = f.Size * 4 / 5;
            //float singleLetterPixelY = f.Size * 5 / 4;
            //g.DrawString(buttonText, f, new SolidBrush(Color.Red), new PointF((Width - (buttonText.Length * singleLetterPixelX)) / 2, (Height - singleLetterPixelY) / 2));

            //g.DrawLine(new Pen(new SolidBrush(Color.Black)), new Point(0, 50), new Point(buttonText.Length*16,50));
        }
    }

    class Ripple
    {
        public int X, Y, Size;
    }
}
