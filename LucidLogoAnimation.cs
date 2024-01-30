using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDraft
{
    class LucidLogoAnimation : UserControl
    {
        private Timer t = new Timer();
        private List<Point[]> polygons = new List<Point[]>();
        private List<Point[]> displayPolygon = new List<Point[]>();
        private int Counter = 0, Iter = 0, delayCount = 0;
        private bool isDelayOccuring = false;

        private void OnLogoMovement(object sender, EventArgs e)
        {
            if(isDelayOccuring)
            {
                if (delayCount <= 20)
                {
                    delayCount += 1;
                }
                else
                {
                    delayCount = 0;
                    isDelayOccuring = false;
                    polygons.Clear();
                    GeneratePolygons();
                    displayPolygon.Clear();
                    Iter = 0;
                }
                this.Invalidate();
                return;
            }

            Counter += 4;
            for (int ctr = 0; ctr < polygons[Iter].Length; ctr++)
            {
                if (Iter == 0)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X, polygons[Iter][ctr].Y + 4);
                else if (Iter == 1)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X - 4, polygons[Iter][ctr].Y + 4);
                else if (Iter == 2)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X - 4, polygons[Iter][ctr].Y);
                else if (Iter == 3)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X - 4, polygons[Iter][ctr].Y - 4);
                else if (Iter == 4)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X, polygons[Iter][ctr].Y - 4);
                else if (Iter == 5)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X + 4, polygons[Iter][ctr].Y - 4);
                else if (Iter == 6)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X + 4, polygons[Iter][ctr].Y);
                else
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X + 4, polygons[Iter][ctr].Y + 4);
            }
            this.Invalidate();

            if (Counter >= 20)
            {
                Counter = 0;
                displayPolygon.Add(polygons[Iter]);
                Iter++;
            }

            if (Iter == polygons.Count)
            {
                isDelayOccuring = true;
               // t.Stop();
            }
                
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            DoubleBuffered = true;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            foreach (var Iter in displayPolygon)
            {
                e.Graphics.FillPolygon(new SolidBrush(Color.Blue), Iter);
            }

            if(Iter<polygons.Count)
            e.Graphics.FillPolygon(new SolidBrush(Color.Blue), polygons[Iter]);
        }

        protected override void OnLoad(EventArgs e)
        {
            t.Interval = 1;
            t.Tick += OnLogoMovement;
            GeneratePolygons();
            t.Start();
        }

        private void GeneratePolygons()
        {
            Point[] p = new Point[3] 
            {
                new Point(Width * 173 / 300, Height * 48 / 300 - 20),
                new Point(Width * 176 / 300, Height * 117 / 300 - 20),
                new Point(Width * 211 / 300, Height * 85 / 300 - 20)
            };
            polygons.Add(p);

            p = new Point[3] 
            {
                new Point(Width * 213 / 300 + 20, Height * 88 / 300 - 20),
                new Point(Width * 181 / 300 + 20, Height * 122 / 300 - 20),
                new Point(Width * 250 / 300 + 20, Height * 124 / 300 - 20)
            };
            polygons.Add(p);
            p = new Point[8] 
            {
                new Point(Width * 180 / 300 + 20, Height * 129 / 300),
                new Point(Width * 252 / 300 + 20, Height * 127 / 300),
                new Point(Width * 277 / 300 + 20, Height * 153 / 300),
                new Point(Width * 266 / 300 + 20, Height * 158 / 300),
                new Point(Width * 256 / 300 + 20, Height * 163 / 300),
                new Point(Width * 247 / 300 + 20, Height * 168 / 300),
                new Point(Width * 236 / 300 + 20, Height * 175 / 300),
                new Point(Width * 229 / 300 + 20, Height * 179 / 300)
            };
            
            polygons.Add(p);

            p = new Point[8] 
            {
                new Point(Width * 176 / 300 + 20, Height * 134 / 300 + 20),
                new Point(Width * 174 / 300 + 20, Height * 237 / 300 + 20),
                new Point(Width * 184 / 300 + 20, Height * 223 / 300 + 20),
                new Point(Width * 191 / 300 + 20, Height * 214 / 300 + 20),
                new Point(Width * 200 / 300 + 20, Height * 204 / 300 + 20),
                new Point(Width * 207 / 300 + 20, Height * 197 / 300 + 20),
                new Point(Width * 217 / 300 + 20, Height * 188 / 300 + 20),
                new Point(Width * 227 / 300 + 20, Height * 181 / 300 + 20)
            };

            polygons.Add(p);

            p = new Point[11]
            {
                new Point(Width * 169 / 300,Height* 135 / 300 + 20),
                new Point(Width * 171 / 300,Height* 241 / 300 + 20),
                new Point(Width * 163 / 300,Height* 254 / 300 + 20),
                new Point(Width * 155 / 300,Height* 269 / 300 + 20),
                new Point(Width * 150 / 300,Height* 279 / 300 + 20),
                new Point(Width * 144 / 300,Height* 266 / 300 + 20),
                new Point(Width * 138 / 300,Height* 252 / 300 + 20),
                new Point(Width * 129 / 300,Height* 237 / 300 + 20),
                new Point(Width * 121 / 300,Height* 225 / 300 + 20),
                new Point(Width * 109 / 300,Height* 210 / 300 + 20),
                new Point(Width * 100 / 300,Height* 200 / 300 + 20)
            };

            polygons.Add(p);

            p = new Point[9]
            {
                new Point(Width * 47 / 300 - 20, Height * 127 / 300 + 20),
                new Point(Width * 164 / 300 - 20, Height * 129 / 300 + 20),
                new Point(Width * 98 / 300 - 20, Height * 198 / 300 + 20),
                new Point(Width * 88 / 300 - 20, Height * 190 / 300 + 20),
                new Point(Width * 76 / 300 - 20, Height * 180 / 300 + 20),
                new Point(Width * 62 / 300 - 20, Height * 171 / 300 + 20),
                new Point(Width * 51 / 300 - 20, Height * 165 / 300 + 20),
                new Point(Width * 39 / 300 - 20, Height * 159 / 300 + 20),
                new Point(Width * 23 / 300 - 20, Height * 152 / 300 + 20)
            };

            polygons.Add(p);

            p = new Point[3] 
            {
                new Point(Width * 109 / 300  - 20, Height * 66 / 300),
                new Point(Width * 163 / 300 - 20, Height * 123 / 300),
                new Point(Width * 49 / 300 - 20, Height * 126 / 300)
            };
            polygons.Add(p);

            p = new Point[4] 
            {
                new Point(Width * 150 / 300 - 20, Height * 25 / 300 - 20),
                new Point(Width * 171 / 300 - 20, Height * 45 / 300 - 20),
                new Point(Width * 168 / 300 - 20, Height * 117 / 300 - 20),
                new Point(Width * 111 / 300 - 20, Height * 64 / 300 - 20)
            };
            polygons.Add(p);
        }

        protected override void OnResize(EventArgs e)
        {
            Width = Height = Math.Max(Height, Width);
        }
    }
}
