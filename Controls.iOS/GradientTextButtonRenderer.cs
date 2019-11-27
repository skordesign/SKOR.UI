using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Skor.Controls;
using Skor.Controls.iOS;
using Skor.Controls.iOS.Extensions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientTextButton), typeof(GradientTextButtonRenderer))]
namespace Skor.Controls.iOS
{
    public class GradientTextButtonRenderer : ViewRenderer<GradientTextButton, UIButton>
    {
        private const float DEFAULT_HEIGHT = 30;
        private const float DEFAULT_WIDTH = 100;
        private GradientTextButton button;
        private UIButton nButton;
        protected override void OnElementChanged(ElementChangedEventArgs<GradientTextButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;

            button = e.NewElement as GradientTextButton;
            nButton = new UIButton(UIButtonType.System);
            nButton.TranslatesAutoresizingMaskIntoConstraints = true;
            nButton.Frame = new CGRect(0, 0, button.WidthRequest != -1 ? button.WidthRequest : DEFAULT_WIDTH,
                button.HeightRequest > 30 ? button.HeightRequest : DEFAULT_HEIGHT);
            button.CornerRadius = button.CornerRadius > (int)(nButton.Frame.Height / 2) ? (int)nButton.Frame.Height / 2 : button.CornerRadius;
            nButton.Layer.CornerRadius = button.CornerRadius;
            nButton.Layer.MasksToBounds = true;
            nButton.TouchUpInside += Handler;
            var longPress = new UILongPressGestureRecognizer();
            longPress.AddTarget(() => button.SendLongClick());
            nButton.GestureRecognizers = new UIGestureRecognizer[] { longPress };
            SetNativeControl(nButton);
        }
        void Handler(object sender, EventArgs e)
        {
            button.SendClicked();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName ==nameof(button.Width) || e.PropertyName == nameof(button.Height))
            {
                CreateBorder();
            }
        }
        void CreateBorder()
        {
            var direction = button.Angle.ToiOS();

            var gradient = new CAGradientLayer();
            gradient.StartPoint = direction[0];
            gradient.EndPoint = direction[1];
            gradient.Frame = new CGRect(0,0, button.Width,button.Height);
            gradient.Colors = new[] {button.StartColor.ToCGColor(), button.CenterColor.ToCGColor(), button.EndColor.ToCGColor()};
                
            var shape = new CAShapeLayer();
            shape.LineWidth =(float) button.BorderWidth;
            shape.Path = UIBezierPath.FromRect(new CGRect(0, 0, button.Width, button.Height)).CGPath;
            shape.StrokeColor = UIColor.Black.CGColor;
            shape.FillColor = UIColor.Clear.CGColor;
            gradient.Mask = shape;
            
            nButton.Layer.AddSublayer(gradient);

            var gradientText = new CAGradientLayer();
            gradientText.StartPoint = direction[0];
            gradientText.EndPoint = direction[1];
            gradientText.Colors = new []{button.StartColor.ToCGColor(),button.CenterColor.ToCGColor(),button.EndColor.ToCGColor()};
            gradientText.Bounds = new CGRect(0, 0, button.Width, button.Height);
            UIGraphics.BeginImageContextWithOptions(gradientText.Bounds.Size, true,(float) 0.0);
            var context = UIGraphics.GetCurrentContext();
            gradientText.RenderInContext(context);
            var image = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            // Create a label and add it as a subview
            var label = new UILabel(new CGRect(0, 0, button.Width, button.Height));
            label.Text = button.Text;
            label.Font = button.Font.ToUIFont();
            label.TextAlignment = UITextAlignment.Center;
            label.TextColor = new UIColor(image);

            nButton.AddSubview(label);
        }
    }
}