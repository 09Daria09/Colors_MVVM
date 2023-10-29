using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colors_MVVM.Models
{
    public class ColorModel
    {
        public byte Alpha { get; set; }
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        public ColorModel(byte Alpha, byte Red, byte Green, byte Blue)
        {
            this.Alpha = Alpha;
            this.Red = Red;
            this.Green = Green;
            this.Blue = Blue;
        }
    }

}
