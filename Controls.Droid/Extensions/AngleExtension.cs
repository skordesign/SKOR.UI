using Android.Graphics.Drawables;

namespace Skor.Controls.Droid.Extensions
{
    public static class AngleExtension
    {
        public static GradientDrawable.Orientation ToAndroid(this AngleGradient angleGradient)
        {
            switch (angleGradient)
            {
                case AngleGradient.BottomLeftTopRight:
                    return GradientDrawable.Orientation.BlTr;
                case AngleGradient.BottomRightTopLeft:
                    return GradientDrawable.Orientation.BrTl;
                case AngleGradient.BottomTop:
                    return GradientDrawable.Orientation.BottomTop;
                case AngleGradient.LeftRight:
                    return GradientDrawable.Orientation.LeftRight;
                case AngleGradient.RightLeft:
                    return GradientDrawable.Orientation.RightLeft;
                case AngleGradient.TopBottom:
                    return GradientDrawable.Orientation.TopBottom;
                case AngleGradient.TopLeftBottomRight:
                    return GradientDrawable.Orientation.TlBr;
                case AngleGradient.TopRightBottomLeft:
                    return GradientDrawable.Orientation.TrBl;
                default:
                    return GradientDrawable.Orientation.LeftRight;
            }
        }
    }
}