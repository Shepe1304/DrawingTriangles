using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingPolygons
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point yUpTmp, yDownTmp, xLeftTmp, xRightTmp, pt1, pt2, lastTmp;
        int lastHeight, lastWidth, cnt = 0, tricnt = 0;
        int ss = 30;
        Point[] Points = new Point[10000], P2 = new Point[10000], P3 = new Point[10000];
        int minimumWidth = 500, minimumHeight = 300;
        int infoShowing = 0;
        int lid = 1, r = 0;
        string[] letterid = new string[10000], info = new string[10000];
        bool onBreak = false;

        void Redraw()
        {
            RedrawOxyGrid();
            RedrawPoints();
        }

        void RedrawOxyGrid()
        {
            Pen p;
            int midx = this.Width / 2, midy = this.Height / 2;
            //Grid
            p = new Pen(Color.LightGray);
            for (int i = midx - ss; i > 0; i -= ss)
            {
                Point pt1 = new Point(i, 0), pt2 = new Point(i, this.Height);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = midx + ss; i < this.Width; i += ss)
            {
                Point pt1 = new Point(i, 0), pt2 = new Point(i, this.Height);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = midy - ss; i > 0; i -= ss)
            {
                Point pt1 = new Point(0, i), pt2 = new Point(this.Width, i);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = midy + ss; i < this.Height; i += ss)
            {
                Point pt1 = new Point(0, i), pt2 = new Point(this.Width, i);
                g.DrawLine(p, pt1, pt2);
            }

            //Oxy
            p = new Pen(Color.Black, 3);
            Point yDown = new Point(midx, this.Height), yUp = new Point(midx, 0);
            Point xLeft = new Point(0, midy), xRight = new Point(this.Width, midy);
            g.DrawLine(p, yUp, yDown);
            g.DrawLine(p, xLeft, xRight);
            ox = midx; oy = midy;
        }

        void ReCalcPoints()
        {
            for (int i = 0; i < cnt; i++)
            {
                Points[i] = new Point(this.Width / 2 - yUpTmp.X + Points[i].X, this.Height / 2 - xLeftTmp.Y + Points[i].Y);
            }
        }

        void RedrawPoints()
        {
            Pen p = new Pen(Color.BlueViolet, 2);

            for (int i = 0; i < cnt; i++)
            {
                int cntmod3 = cnt % 3; if (cntmod3 == 0) cntmod3 = 3;
                if (i >= (cnt - (cntmod3)))
                    p = new Pen(Color.Red, 2);
                if ((i + 1) % 3 == 0)
                    g.DrawLine(p, Points[i], Points[i - 2]);
                else if (i < cnt - 1)
                    g.DrawLine(p, Points[i], Points[i + 1]);
            }

            for (int i = 0; i < cnt; i++)
            {
                string pos = letterid[i] + " (" + (P2[i].X).ToString() + "; " + (-P2[i].Y).ToString() + ")";
                for (int j = 0; j < 2; j++)  TextRenderer.DrawText(g, pos, Form1.DefaultFont, Points[i], BackColor);
                TextRenderer.DrawText(g, pos, Form1.DefaultFont, Points[i], Color.Black);
            }
        }


        void Delete()
        {
            DeleteOxyGrid();
            DeletePoints();
        }

        void DeleteOxyGrid()
        {
            Pen p = new Pen(this.BackColor, 1);
            //Grid
            for (int i = yUpTmp.X - ss; i > 0; i -= ss)
            {
                Point pt1 = new Point(i, 0), pt2 = new Point(i, lastHeight);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = yUpTmp.X + ss; i < lastWidth; i += ss)
            {
                Point pt1 = new Point(i, 0), pt2 = new Point(i, lastHeight);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = xLeftTmp.Y - ss; i > 0; i -= ss)
            {
                Point pt1 = new Point(0, i), pt2 = new Point(lastWidth, i);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = xLeftTmp.Y + ss; i < lastHeight; i += ss)
            {
                Point pt1 = new Point(0, i), pt2 = new Point(lastWidth, i);
                g.DrawLine(p, pt1, pt2);
            }
            //Old Oxy
            p = new Pen(this.BackColor, 3);
            g.DrawLine(p, xLeftTmp, xRightTmp);
            g.DrawLine(p, yUpTmp, yDownTmp);
        }

        void DeletePoints()
        {
            Pen p;
            //Old triangle
            p = new Pen(this.BackColor, 2);
            for (int i = 0; i < cnt; i++)
            {

                if ((i + 1) % 3 == 0)
                    g.DrawLine(p, Points[i], Points[i - 2]);
                else if (i < cnt - 1)
                    g.DrawLine(p, Points[i], Points[i + 1]);
            }

            for (int i = 0; i < cnt; i++)
            {
                string pos = letterid[i] + " (" + (P2[i].X).ToString() + "; " + (-P2[i].Y).ToString() + ")";
                for (int j = 0; j < 5; j++) TextRenderer.DrawText(g, pos, Form1.DefaultFont, Points[i], BackColor);
            }
        }

        private void btn_zout_Click(object sender, EventArgs e)
        {
            if (!first)
            {
                MessageBox.Show("Finish drawing line first!");
            }
            else
            {
                if (ss == 10)
                {
                    MessageBox.Show("Can not zoom out anymore!");
                }
                else
                {
                    Delete();
                    ss -= 10;
                    RedrawOxyGrid();
                    double k = 1.0 * ss / (ss + 10);
                    for (int i = 0; i < cnt; i++)
                    {
                        Points[i].X = (int)Math.Round(1.0 * k * (Points[i].X - ox) + ox);
                        Points[i].Y = (int)Math.Round(1.0 * k * (Points[i].Y - oy) + oy);
                    }
                    RedrawPoints();
                }
            }
        }

        private void btn_zin_Click(object sender, EventArgs e)
        {
            if (!first)
            {
                MessageBox.Show("Finish drawing line first!");
            }
            else
            {
                Delete();
                ss += 10;
                RedrawOxyGrid();
                double k = 1.0 * ss / (ss - 10);
                for (int i = 0; i < cnt; i++)
                {
                    Points[i].X = (int)Math.Round(1.0 * k * (Points[i].X - ox) + ox);
                    Points[i].Y = (int)Math.Round(1.0 * k * (Points[i].Y - oy) + oy);
                }
                RedrawPoints();
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (cnt < 3)
            {
                MessageBox.Show("Please draw first!");
            }
            else if (!first)
            {
                MessageBox.Show("Please finish drawing!");
            }
            else
            {
                Pen p = new Pen(BackColor, 2);
                g.DrawLine(p, Points[cnt - 1], Points[cnt - 2]);
                g.DrawLine(p, Points[cnt - 2], Points[cnt - 3]);
                g.DrawLine(p, Points[cnt - 1], Points[cnt - 3]);
                for (int i = cnt - 1; i >= cnt - 3; i--)
                {
                    string pos = letterid[i] + " (" + (P2[i].X).ToString() + "; " + (-P2[i].Y).ToString() + ")";
                    for (int j = 0; j < 5; j++) TextRenderer.DrawText(g, pos, Form1.DefaultFont, Points[i], BackColor);
                }

                cnt -= 3;

                if (cnt >= 3)
                {
                    p = new Pen(Color.Red, 2);
                    g.DrawLine(p, Points[cnt - 1], Points[cnt - 2]);
                    g.DrawLine(p, Points[cnt - 2], Points[cnt - 3]);
                    g.DrawLine(p, Points[cnt - 1], Points[cnt - 3]);
                }

                Redraw();

                tricnt--;
                rtxtOut.Text = "";
                for (int i = 0; i < tricnt; i++)
                {
                    rtxtOut.Text = info[i] + rtxtOut.Text;
                }
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            infoShowing = 1 - infoShowing;
            if (infoShowing == 1)
            {
                rtxtOut.Location = new Point(0, btnOut.Height);
                rtxtOut.Width = this.Width / 5;
                rtxtOut.Height = this.Height;
                btnOut.Text = "Hide Information";
            }
            else
            {
                rtxtOut.Width = 0;
                rtxtOut.Height = 0;
                btnOut.Text = "Show Information";
            }
        }

        void resizingButtons()
        {
            btn_delete.Width = this.Width / 10;
            btn_delete.Height = this.Height / 10;
            btn_delete.Location = new Point(this.Width - btn_delete.Width - 20, 0);

            btn_zin.Width = this.Width / 10;
            btn_zin.Height = this.Height / 10;
            btn_zin.Location = new Point(this.Width - btn_zin.Width - 20, btn_delete.Height + 10);

            btn_zout.Width = this.Width / 10;
            btn_zout.Height = this.Height / 10;
            btn_zout.Location = new Point(this.Width - btn_zout.Width - 20, btn_delete.Height + btn_zin.Height + 20);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 500;

            resizingButtons();
        }

        bool first = true;

        int ox, oy;

        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            btnOut.Width = this.Width / 5;
            btnOut.Height = this.Height / 10;
            rtxtOut.Width = 0;
            rtxtOut.Height = 0;
        }

        void writeInfo()
        {
            Point a, b, c; a = Points[cnt - 3]; b = Points[cnt - 2]; c = Points[cnt - 1];
            a = new Point(P2[cnt - 3].X, -P2[cnt - 3].Y);
            b = new Point(P2[cnt - 2].X, -P2[cnt - 2].Y);
            c = new Point(P2[cnt - 1].X, -P2[cnt - 1].Y);

            double area = 1.0 * ((b.X - a.X) * (b.Y + a.Y) + (c.X - b.X) * (c.Y + b.Y) + (a.X - c.X) * (a.Y + c.Y)) / 2;
            double ab = Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
            double ac = Math.Sqrt((a.X - c.X) * (a.X - c.X) + (a.Y - c.Y) * (a.Y - c.Y));
            double bc = Math.Sqrt((c.X - b.X) * (c.X - b.X) + (c.Y - b.Y) * (c.Y - b.Y));
            double p = (ab + ac + bc) / 2;
            string currentTriInfo;
            currentTriInfo = "TRIANGLE " + letterid[cnt - 3] + letterid[cnt - 2] + letterid[cnt - 1] + ": \r\n\r\n";
            currentTriInfo += "COORDINATES: " + letterid[cnt - 3] + "(" + a.X + ", " + a.Y + "); " + letterid[cnt - 2] + "(" + b.X + ", " + b.Y + "); " + letterid[cnt - 1] + "(" + c.X + ", " + c.Y + "). \r\n\r\n";
            currentTriInfo += "LENGTH OF EDGES: " + letterid[cnt - 3] + letterid[cnt - 2] + " = " + ab + "; " + letterid[cnt - 2] + letterid[cnt - 1] + " = " + bc + "; " + letterid[cnt - 3] + letterid[cnt - 1] + " = " + ac + ".\r\n\r\n";
            currentTriInfo += "PARAMETER: " + p + ".\r\n\r\n";
            currentTriInfo += "AREA: " + Math.Abs(area) + ".\r\n";
            info[tricnt] = currentTriInfo; tricnt++;
            rtxtOut.Text = currentTriInfo + "\r\n\r\n\r\n\r\n" + rtxtOut.Text + "\r\n\r\n\r\n\r\n";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (!onBreak)
            {
                g = this.CreateGraphics();
                Pen p = new Pen(Color.Red, 2);
                if (first)
                {
                    pt1 = e.Location;
                    first = false;
                    double tx = pt1.X - ox, ty = pt1.Y - oy;
                    P2[cnt] = new Point((int)Math.Round(tx / ss) * ss, (int)Math.Round(ty / ss) * ss);
                    pt1 = new Point(ox + P2[cnt].X, oy + P2[cnt].Y);
                    P2[cnt] = new Point(P2[cnt].X / ss, P2[cnt].Y / ss);
                    Points[cnt] = pt1;
                    int dupid = 0;
                    for (int i = 0; i < cnt; i++)
                    {
                        if (P2[i] == P2[cnt])
                        {
                            dupid = i+1;
                            break;
                        }
                    }
                    if (dupid > 0) letterid[cnt] = letterid[dupid - 1];
                    else
                    {
                        string rr = ""; if (r != 0) rr = r.ToString();
                        letterid[cnt] = (char)(lid + 64) + rr;
                        if (lid == 26)
                        {
                            lid = 1;
                            r++;
                        }
                        else lid++;
                    }
                    cnt++;
                }
                else
                {
                    pt2 = e.Location;
                    Pen p1 = new Pen(this.BackColor, 2);
                    g.DrawLine(p1, pt1, pt2);
                    double tx = pt2.X - ox, ty = pt2.Y - oy;
                    P2[cnt] = new Point((int)Math.Round(tx / ss) * ss, (int)Math.Round(ty / ss) * ss);
                    pt2 = new Point(ox + P2[cnt].X, oy + P2[cnt].Y);
                    P2[cnt] = new Point(P2[cnt].X / ss, P2[cnt].Y / ss);
                    Points[cnt] = pt2;
                    int dupid = 0;
                    for (int i = 0; i < cnt; i++)
                    {
                        if (P2[i] == P2[cnt])
                        {
                            dupid = i + 1;
                            break;
                        }
                    }
                    if (dupid > 0) letterid[cnt] = letterid[dupid - 1];
                    else
                    {
                        string rr = ""; if (r != 0) rr = r.ToString();
                        letterid[cnt] = (char)(lid + 64) + rr;
                        if (lid == 26)
                        {
                            lid = 1;
                            r++;
                        }
                        else lid++;
                    }
                    cnt++;
                    g.DrawLine(p, pt1, pt2);
                    pt1 = pt2;
                }
                string pos = letterid[cnt - 1] + " (" + (P2[cnt - 1].X).ToString() + "; " + (-P2[cnt - 1].Y).ToString() + ")";
                TextRenderer.DrawText(g, pos, Form1.DefaultFont, Points[cnt - 1], Color.Black);
                if (cnt % 3 == 0)
                {
                    g.DrawLine(p, Points[cnt - 1], Points[cnt - 3]);
                    writeInfo();
                    first = true;
                }
                Redraw();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen p;
            RedrawPoints();
            //Mouse Move code:
            if (!first)
            {
                g = this.CreateGraphics();
                //delete old
                p = new Pen(this.BackColor);
                Point tmp = new Point(); tmp = e.Location;
                g.DrawLine(p, pt1, lastTmp);

                //draw new
                p = new Pen(Color.Red);
                g.DrawLine(p, pt1, tmp);

                ReCalcPoints();
                Redraw();

                //save position
                lastTmp = tmp;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            int midx = this.Width / 2, midy = this.Height / 2;
            //Grid
            Pen p = new Pen(Color.LightGray);
            for (int i = midx - ss; i > 0; i -= ss)
            {
                Point pt1 = new Point(i, 0), pt2 = new Point(i, this.Height);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = midx + ss; i < this.Width; i += ss)
            {
                Point pt1 = new Point(i, 0), pt2 = new Point(i, this.Height);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = midy - ss; i > 0; i -= ss)
            {
                Point pt1 = new Point(0, i), pt2 = new Point(this.Width, i);
                g.DrawLine(p, pt1, pt2);
            }
            for (int i = midy + ss; i < this.Height; i += ss)
            {
                Point pt1 = new Point(0, i), pt2 = new Point(this.Width, i);
                g.DrawLine(p, pt1, pt2);
            }
            //draw x and y axises
            p = new Pen(Color.Black, 3);
            ox = midx; oy = midy;
            Point yDown = new Point(midx, this.Height), yUp = new Point(midx, 0);
            Point xLeft = new Point(0, midy), xRight = new Point(this.Width, midy);
            g.DrawLine(p, yUp, yDown);
            g.DrawLine(p, xLeft, xRight);
            xLeftTmp = xLeft; xRightTmp = xRight; yUpTmp = yUp; yDownTmp = yDown;
            lastHeight = this.Height;
            lastWidth = this.Width;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!first)
            {
                this.Width = lastWidth;
                this.Height = lastHeight;
            }
            if (this.Width < minimumWidth) this.Width = minimumWidth;
            if (this.Height < minimumHeight) this.Height = minimumHeight;

            g = this.CreateGraphics();

            Delete();
            ReCalcPoints();
            Redraw();
            //save the latest measurements
            int midx = this.Width / 2, midy = this.Height / 2;
            Point yDown = new Point(midx, this.Height), yUp = new Point(midx, 0);
            Point xLeft = new Point(0, midy), xRight = new Point(this.Width, midy);
            xLeftTmp = xLeft; xRightTmp = xRight; yUpTmp = yUp; yDownTmp = yDown;
            lastHeight = this.Height;
            lastWidth = this.Width;

            btnOut.Width = this.Width / 5;
            btnOut.Height = this.Height / 10;
            if (infoShowing == 1)
            {
                rtxtOut.Location = new Point(0, btnOut.Height);
                rtxtOut.Width = this.Width / 5;
                rtxtOut.Height = this.Height;
            }
            resizingButtons();
        }
    }
}