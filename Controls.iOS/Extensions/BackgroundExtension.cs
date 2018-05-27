using CoreAnimation;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Skor.Controls.iOS.Extensions
{
    public static class BackgroundExtension
    {
        public static CAGradientLayer CreateBackgroundGradientLayer(float height, float width, float corner, UIColor startColor, UIColor endColor,
           UIColor centerColor, CGPoint[] direction = null)
        {
            var gradientLayer = new CAGradientLayer();
            if (centerColor != Color.Transparent.ToUIColor())
            {
                gradientLayer.Colors = new[] { startColor.CGColor,centerColor.CGColor, endColor.CGColor };
            }
            else
            {
                gradientLayer.Colors = new[] { startColor.CGColor, endColor.CGColor };
            }
            var d = direction ?? new CGPoint[] { new CGPoint(0, 0), new CGPoint(1, 0) };
            gradientLayer.StartPoint = d[0];
            gradientLayer.EndPoint = d[1];
            gradientLayer.Frame = new CGRect(0, 0, width, height);
            gradientLayer.CornerRadius = corner;
            return gradientLayer;
        }
        public static CALayer CreateBackgroundImage(float height, float width, float corner, string source)
        {
            var cALayer = new CALayer();
            var image = new UIImage(source).CGImage;
            
            cALayer.Frame = new CGRect(0, 0, width, height);
            cALayer.Contents = image;
            cALayer.CornerRadius = corner;
            cALayer.Opacity = 0.4f;
            cALayer.MasksToBounds = true;
            return cALayer;
        }
    }
}