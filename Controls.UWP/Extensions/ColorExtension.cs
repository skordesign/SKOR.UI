using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skor.Controls.UWP.Extensions
{
    public static class ColorExtension
    {
        public static Windows.UI.Color ToWindows(this Xamarin.Forms.Color color)
        {
            return Windows.UI.Color.FromArgb(Convert.ToByte(color.A * 255), Convert.ToByte(color.R * 255), Convert.ToByte(color.G * 255), Convert.ToByte(color.B * 255));
        }
    }
}
