using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace Skor.Controls.UWP.Extensions
{
    public static class AngleExtension
    {
        public static Point[] ToWindows(this AngleGradient angleGradient)
        {
            switch (angleGradient)
            {
                case AngleGradient.BottomLeftTopRight:
                    return new Point[] { new Point(0, 0), new Point(1, 1) };
                case AngleGradient.BottomRightTopLeft:
                    return new Point[] { new Point(1, 0), new Point(0, 1) };
                case AngleGradient.BottomTop:
                    return new Point[] { new Point(0, 0), new Point(0, 1) };
                case AngleGradient.LeftRight:
                    return new Point[] { new Point(0, 0), new Point(1, 0) };
                case AngleGradient.RightLeft:
                    return new Point[] { new Point(1, 0), new Point(0, 0) };
                case AngleGradient.TopBottom:
                    return new Point[] { new Point(0, 1), new Point(0, 0) };
                case AngleGradient.TopLeftBottomRight:
                    return new Point[] { new Point(1, 0), new Point(0, 1) };
                case AngleGradient.TopRightBottomLeft:
                    return new Point[] { new Point(1, 1), new Point(0, 0) };
                default:
                    return new Point[] { new Point(0, 0), new Point(1, 0) };
            }
        }
    }
}
