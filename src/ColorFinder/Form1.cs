using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;

namespace ColorFinder
{
    public partial class Form1 : Form
    {
        private Point lastPosition;
        private bool firstTime;
        private const int WM_MOUSEMOVE = 0x0200;


        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        public Form1()
        {
            firstTime = true;
            InitializeComponent();

            Timer timer = new Timer();
            timer.Tick += MouseMoveTimer_Tick;
            timer.Interval = 100;
            timer.Start();
        }

        private void MouseMoveTimer_Tick(object sender, EventArgs e)
        {
            Point cursor = new Point();
            GetCursorPos(ref cursor);
            if (firstTime)
            {
                lastPosition = cursor;
                Text = GetColorAt(cursor).ToString();
                firstTime = false;
                System.Diagnostics.Debug.WriteLine("firstTime");
            }

            if (lastPosition.X != cursor.X && lastPosition.Y != cursor.Y)
            {
                System.Diagnostics.Debug.WriteLine("{0} - {1}", lastPosition, cursor);
                lastPosition = cursor;
                Text = GetColorAt(cursor).ToString();
                System.Diagnostics.Debug.WriteLine("change");
            }
        }


        public Color GetColorAt(Point location)
        {
            Color color = Color.White;
            Bitmap screenPixel = new Bitmap(17, 17, PixelFormat.Format32bppArgb);
            using (var gdest = Graphics.FromImage(screenPixel))
            {
                using (var gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    var hSrcDC = gsrc.GetHdc();
                    var hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 17, 17, hSrcDC, location.X - 8, location.Y - 8, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            Bitmap background = new Bitmap(272, 272, PixelFormat.Format32bppArgb);

            for (int i = 0; i < screenPixel.Width; i++)
            {
                for (int i2 = 0; i2 < 15; i2++)
                {
                    for (int j = 0; j < screenPixel.Height; j++)
                    {
                        var pixel = screenPixel.GetPixel(i, j);
                        for (int k = 0; k < 15; k++)
                        {
                            background.SetPixel(i, j, Color.FromArgb(pixel.ToArgb()));
                        }
                    }
                }
            }

            panel1.BackgroundImage = screenPixel;
            System.Diagnostics.Debug.WriteLine(screenPixel.GetPixel(0, 0).ToString());
            //color = screenPixel.GetPixel(0, 0);
            return color;
        }
    }
}
