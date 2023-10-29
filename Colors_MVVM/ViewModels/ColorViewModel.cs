using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using Colors_MVVM.Commands;
using Colors_MVVM.Models;

namespace Colors_MVVM.ViewModels
{
    internal class ColorViewModel : ViewModelBase
    {
        private ColorModel Colors;
        public ColorViewModel()
        {
            Colors = new ColorModel(0, 0, 0, 0);
        }
        public string DisplayHex
        {
            get { return $"#{Alpha:X2}{Red:X2}{Green:X2}{Blue:X2}"; }
        }

        public SolidColorBrush BackgroundColor { get; set;}
        public byte Alpha
        {
            get { return Colors.Alpha; } set { Colors.Alpha = value; }
        }
        public byte Red
        {
            get { return Colors.Red; } set { Colors.Red = value; }
        }
        public byte Green
        {
            get { return Colors.Green; } set { Colors.Green = value; }
        }
        public byte Blue
        {
            get { return Colors.Blue; } set { Colors.Blue = value; }
        }

        public ColorViewModel Copy()
        {
            return new ColorViewModel
            {
                Alpha = this.Alpha,
                Red = this.Red,
                Green = this.Green,
                Blue = this.Blue
            };
        }
        public Color ColorValue
        {
            get
            {
                return Color.FromArgb(Alpha, Red, Green, Blue);
            }
        }

    }
}
