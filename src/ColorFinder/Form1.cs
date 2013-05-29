using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ColorFinder.UserActivityMonitor;

namespace ColorFinder
{
    public partial class Form1 : Form
    {
        IKeyboardHook hook;
        private ColorProperties colorProps;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern int BitBlt(IntPtr hDC, int x, int y, int nWidth, int nHeight, IntPtr hSrcDC, int xSrc, int ySrc, int dwRop);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public Form1()
        {
            InitializeComponent();
            colorProps = new ColorProperties();
            Load += (sender, args) =>
            {
                txtHexadecimal.DataBindings.Add("Text", colorProps, "ActualColorHex");
                txtARBG.DataBindings.Add("Text", colorProps, "ActualColorRGB");
                txtColorDiff.DataBindings.Add("Text", colorProps, "ActualColorDiff");
                panel2.DataBindings.Add("BackColor", colorProps, "ActualColor");

                Location = new Point(SystemInformation.WorkingArea.Width - Width - 20, SystemInformation.WorkingArea.Height - Height - 50);

                HookManager.MouseMove += HookManagerMouseMove;
                hook = KeyboardHooks.Create();
                hook.KeyPressed += HandleHootkey;
                hook.RegisterHotKey(ColorFinder.ModifierKeys.Control, Keys.D);
                hook.RegisterHotKey(ColorFinder.ModifierKeys.Control | ColorFinder.ModifierKeys.Shift, Keys.D);
            };
            Application.ApplicationExit += (sender, args) =>
            {
                hook.Dispose();
                niColorFinder.Visible = false;
                niColorFinder.Dispose();
            };
        }

        private void HandleHootkey(object sender, KeyPressedEventArgs eventArgs)
        {
            if (eventArgs.Modifier == ColorFinder.ModifierKeys.Control &&
                eventArgs.Key == Keys.D)
            {
                Clipboard.SetText(txtColorDiff.Text);
                niColorFinder.ShowBalloonTip(1000, "Color Finder", "Color diff copiado", ToolTipIcon.Info);
            }
            else if (eventArgs.Modifier == (ColorFinder.ModifierKeys.Control | ColorFinder.ModifierKeys.Shift) &&
                     eventArgs.Key == Keys.D)
            {
                Clipboard.SetText(txtHexadecimal.Text);
                niColorFinder.ShowBalloonTip(1000, "Color Finder", "Hexadecimal copiado", ToolTipIcon.Info);
            }
        }

        private void HookManagerMouseMove(object sender, MouseEventArgs e)
        {
            GetColorAt(e.Location);
        }

        public void GetColorAt(Point point)
        {
            var screenPixel = new Bitmap(1, 1, PixelFormat.Format32bppArgb);
            using (var gdest = Graphics.FromImage(screenPixel))
            using (var gsrc = Graphics.FromHwnd(IntPtr.Zero))
            {
                var hSrcDC = gsrc.GetHdc();
                var hDC = gdest.GetHdc();
                var retval = BitBlt(hDC, 0, 0, 1, 1, hSrcDC, point.X, point.Y, (int)CopyPixelOperation.SourceCopy);
                gdest.ReleaseHdc();
                gsrc.ReleaseHdc();
            }

            colorProps.ActualColor = screenPixel.GetPixel(0, 0);
        }

        private void TextBox1KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var replace = textBox1.Text.Replace("#", "");
                if (replace.Length == 2)
                {
                    replace = replace + replace + replace;
                    textBox1.Text = string.Format("#{0}", replace);
                    var a = Convert.ToInt32("FF" + replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
                else if (replace.Length == 3)
                {
                    replace = replace + replace;
                    textBox1.Text = string.Format("#{0}", replace);
                    var a = Convert.ToInt32("FF" + replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
                else if (replace.Length == 6)
                {
                    textBox1.Text = string.Format("#{0}", replace);
                    var a = Convert.ToInt32("FF" + replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
                else if (replace.Length == 8)
                {
                    var a = Convert.ToInt32(replace, 16);
                    panel3.BackColor = Color.FromArgb(a);
                }
            }
        }
    }
}