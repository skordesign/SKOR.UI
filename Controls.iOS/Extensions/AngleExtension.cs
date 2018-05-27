using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using UIKit;

namespace Skor.Controls.iOS.Extensions
{
    public static class AngleExtension
    {
        public static CGPoint[] ToiOS(this AngleGradient angleGradient)
        {
            switch (angleGradient)
            {
                case AngleGradient.BottomLeftTopRight:
                    return new CGPoint[] { new CGPoint(0, 0), new CGPoint(1, 1) };
                case AngleGradient.BottomRightTopLeft:
                    return new CGPoint[] { new CGPoint(1, 0), new CGPoint(0, 1) };
                case AngleGradient.BottomTop:
                    return new CGPoint[] { new CGPoint(1, 0), new CGPoint(1, 1) };
                case AngleGradient.LeftRight:
                    return new CGPoint[] { new CGPoint(0, 0), new CGPoint(1, 0) };
                case AngleGradient.RightLeft:
                    return new CGPoint[] { new CGPoint(1, 0), new CGPoint(0, 0) };
                case AngleGradient.TopBottom:
                    return new CGPoint[] { new CGPoint(0, 1), new CGPoint(0, 0) };
                case AngleGradient.TopLeftBottomRight:
                    return new CGPoint[] { new CGPoint(0, 1), new CGPoint(1, 0) };
                case AngleGradient.TopRightBottomLeft:
                    return new CGPoint[] { new CGPoint(1, 1), new CGPoint(0, 0) };
                default:
                    return new CGPoint[] { new CGPoint(0, 0), new CGPoint(1, 0) };
            }
        }
    }
}