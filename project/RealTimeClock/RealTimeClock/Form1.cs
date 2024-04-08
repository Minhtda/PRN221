namespace RealTimeClock
{
    public partial class Form1 : Form
    {

        int WIDTH = 300, HEIGHT = 300, secHAND = 140, minHAND = 110, hrHAND = 80;

        //center
        int cx, cy;

        Bitmap bmp;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void t_Tick()
        {
            g = Graphics.FromImage(bmp);
            int ss = DateTime.Now.Second;
            int mm = DateTime.Now.Minute;
            int hh = DateTime.Now.Hour;
            int[] handCoord = new int[2];
            g.Clear(Color.White);
            g.DrawEllipse(new Pen(Color.Black, 1f), 0, 0, WIDTH, HEIGHT);
            g.DrawString("12", new Font("Arial", 12), Brushes.Black, new PointF(140, 2));
            g.DrawString("3", new Font("Arial", 12), Brushes.Black, new PointF(286, 140));
            g.DrawString("6", new Font("Arial", 12), Brushes.Black, new PointF(142, 282));
            g.DrawString("9", new Font("Arial", 12), Brushes.Black, new PointF(0, 140));
            handCoord = msCoord(ss, secHAND);
            Pen p1 = new Pen(Color.Red, 1f);
            p1.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p1, new Point(handCoord[0], handCoord[1]), new Point(cx, cy));
            handCoord = msCoord(mm, minHAND);
            Pen p2 = new Pen(Color.Black, 2f);
            p2.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p2, new Point(handCoord[0], handCoord[1]), new Point(cx, cy));
            handCoord = hrCoord(hh % 12, mm, hrHAND);
            Pen p3 = new Pen(Color.Black, 2f);
            p3.StartCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            g.DrawLine(p3, new Point(handCoord[0], handCoord[1]), new Point(cx, cy));
            pictureBox1.Image = bmp;
            g.Dispose();
        }

        private int[] msCoord(int val, int hlen)
        {
            int[] coord = new int[2];
            val *= 6;

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

        private int[] hrCoord(int hval, int mval, int hlen)
        {
            int[] coord = new int[2];
            int val = (int)((hval * 30) + (mval * 0.5));

            if (val >= 0 && val <= 180)
            {
                coord[0] = cx + (int)(hlen * Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            else
            {
                coord[0] = cx - (int)(hlen * -Math.Sin(Math.PI * val / 180));
                coord[1] = cy - (int)(hlen * Math.Cos(Math.PI * val / 180));
            }
            return coord;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //bmp = new Bitmap(WIDTH + 1, HEIGHT + 1);
            //cx = WIDTH / 2;
            //cy = HEIGHT / 2;
            //this.BackColor = Color.White;

            //Task task03 = new Task(new Action(() => { drawClock(); }));
            //task03.Start();
        }
        private async void drawClock()
        {
            int i = 0;
            do
            {
                t_Tick();
                Thread.Sleep(1000);
            }
            while (i == 0);
        }
    }
}