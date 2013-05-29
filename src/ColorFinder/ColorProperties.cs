using System.ComponentModel;
using System.Drawing;

namespace ColorFinder
{
    public class ColorProperties : INotifyPropertyChanged
    {
        private Color actualColor;
        private Color baseColor;
        private string actualColorRGB;
        private string actualColorDiff;

        public Color ActualColor
        {
            get { return actualColor; }
            set
            {
                actualColor = value;
                OnPropertyChanged("ActualColor");
                OnPropertyChanged("ActualColorHex");
                OnPropertyChanged("ActualColorRGB");
            }
        }

        public Color BaseColor
        {
            get { return baseColor; }
            set
            {
                baseColor = value;
                OnPropertyChanged("BaseColor");
            }
        }

        public string ActualColorHex
        {
            get { return string.Format("#{0:X2}{1:X2}{2:X2}", (int)ActualColor.R, (int)ActualColor.G, (int)ActualColor.B); }
            set
            {
                //actualColorHex = value;
                //OnPropertyChanged("ActualColorHex");
            }
        }

        public string ActualColorRGB
        {
            get { return string.Format("{0},{1},{2}", (int)ActualColor.R, (int)ActualColor.G, (int)ActualColor.B); }
            set
            {
                actualColorRGB = value;
                OnPropertyChanged("ActualColorRGB");
            }
        }

        public string ActualColorDiff
        {
            get
            {
                const string format = "original_color: {0:X4}, red:{1}, green:{2}, blue:{3}";
                return string.Format(format, ActualColorHex, ColorDiff(ActualColor.R, BaseColor.R), ColorDiff(ActualColor.G, BaseColor.G), ColorDiff(ActualColor.B, BaseColor.B));
            }
            set
            {
                actualColorDiff = value;
                OnPropertyChanged("ActualColorDiff");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        private static string ColorDiff(int channelA, int channelB)
        {
            double basis, diff, percentDiff = 0;

            if (channelA > channelB)
            {
                basis = channelA;
                diff = channelA - channelB;
                percentDiff = -(diff / (basis / 100));
            }

            if (channelA < channelB)
            {
                basis = 255 - channelA;
                diff = channelB - channelA;
                percentDiff = diff / (basis / 100);
            }
            return percentDiff.ToString("0.00");
        }

    }
}