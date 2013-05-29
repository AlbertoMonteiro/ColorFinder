using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ColorFinder.UserActivityMonitor;

namespace ColorFinder
{
    public partial class Form1 : Form
    {
        private const int WM_DRAWCLIPBOARD = 0x308;
        private const int WM_CHANGECBCHAIN = 0x030D;

        IntPtr nextClipboardViewer;

        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        public Form1()
        {
            InitializeComponent();

            nextClipboardViewer = (IntPtr)SetClipboardViewer((int)Handle);
            Load += (sender, args) =>
            {
                HookManager.MouseMove += HookManagerMouseMove;
                /*HookManager.KeyDown += HookManagerKeyDown;*/
            };
        }

        private void HookManagerMouseMove(object sender, MouseEventArgs e)
        {
            GetColorAt(e.Location);
        }

        public void GetColorAt(Point point)
        {
            var screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            using (var gdest = Graphics.FromImage(screenPixel))
            {
                using (var gsrc = Graphics.FromHwnd(IntPtr.Zero))
                {
                    var hSrcDC = gsrc.GetHdc();
                    var hDC = gdest.GetHdc();
                    int retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, point.X, point.Y, (int)CopyPixelOperation.SourceCopy);
                    gdest.ReleaseHdc();
                    gsrc.ReleaseHdc();
                }
            }

            panel1.BackColor = screenPixel.GetPixel(0, 0);
            textBox2.Text = string.Format("{0},{1},{2},{3}", (int)panel1.BackColor.A, (int)panel1.BackColor.R, (int)panel1.BackColor.G, (int)panel1.BackColor.B);
            textBox3.Text = string.Format("#{0:X4}", panel1.BackColor.ToArgb());
            textBox4.Text = CheckColorDiff(panel1.BackColor);
        }

        private string CheckColorDiff(Color colorB)
        {
            double basis, diff, percentDiff = 0;

            Color colorA = panel3.BackColor;

            Func<int, int, string> colorDiff = (channelA, channelB) =>
            {
                if (channelA > channelB)
                {
                    basis = channelA;
                    diff = channelA - channelB;
                    percentDiff = -(diff/(basis/100));
                }

                if (channelA < channelB)
                {
                    basis = 255 - channelA;
                    diff = channelB - channelA;
                    percentDiff = -(diff/(basis/100));
                }
                return percentDiff.ToString("0.00");
            };


            return string.Format("original_color: {0:X4}, red:{1}, green:{2}, blue:{3}", colorA.ToArgb(), colorDiff(colorA.R, colorB.R), colorDiff(colorA.G, colorB.G), colorDiff(colorA.B, colorB.B));
        }

        private void TextBox1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var replace = textBox1.Text.Replace("#", "");
                if (replace.Length == 2)
                {
                    replace = "FF" + replace + replace + replace;
                    textBox1.Text = string.Format("#{0}", replace);
                    var a = Convert.ToInt32(replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
                else if (replace.Length == 3)
                {
                    replace = "FF" + replace + replace;
                    textBox1.Text = string.Format("#{0}", replace);
                    var a = Convert.ToInt32(replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
                else if (replace.Length == 6)
                {
                    replace = "FF" + replace;
                    textBox1.Text = string.Format("#{0}", replace);
                    var a = Convert.ToInt32(replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
                else if (replace.Length == 8)
                {
                    var a = Convert.ToInt32(replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
            }
        }

        private void CheckBox1CheckedChanged(object sender, EventArgs e)
        {
        }

/*
        private void HookManagerKeyDown(object sender, KeyEventArgs e)
        {
            if (checkBox1.Checked)
            {
                if (e.Control || e.KeyCode == Keys.Control || e.KeyCode == Keys.ControlKey)
                {
                    if (e.KeyCode == Keys.C)
                    {
                        var checkColorDiff = CheckColorDiff(panel1.BackColor);
                        Clipboard.SetText(checkColorDiff);
                        Debug.WriteLine(checkColorDiff);
                    } 
                }
            }
        }
*/
    }
}
