using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Foundation;
using Skor.Controls;
using Skor.Controls.iOS;
using Skor.Controls.iOS.Extensions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientFrame), typeof(GradientFrameRenderer))]
namespace Skor.Controls.iOS
{
    public class GradientFrameRenderer: FrameRenderer
    {
        private GradientFrame frame;
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                frame = e.NewElement as GradientFrame;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Width" || e.PropertyName == "Height")
            {
                Layer.BackgroundColor = UIColor.Clear.CGColor;
                Layer.BorderColor = UIColor.Clear.CGColor;
                Layer.BorderWidth = 0;
                Layer.InsertSublayer(BackgroundExtension.CreateBackgroundGradientLayer((float)frame.Height, (float)frame.Width, frame.CornerRadius, frame.StartColor.ToUIColor(),
                    frame.EndColor.ToUIColor(), frame.CenterColor.ToUIColor(), frame.Angle.ToiOS()), 0);
                if (frame.Image != null && frame.Image.File.Length > 0)
                {
                    var background = BackgroundExtension.CreateBackgroundImage((float)frame.Height, (float)frame.Width, frame.CornerRadius, frame.Image.File);
                    Layer.InsertSublayer(background, 0);
                }
            }
        }
    }
}