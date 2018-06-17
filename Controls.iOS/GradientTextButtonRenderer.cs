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
            button = e.NewElement as GradientTextButton;
            nButton = new UIButton(UIButtonType.System);
            nButton.TranslatesAutoresizingMaskIntoConstraints = true;
            nButton.Frame = new CGRect(0, 0, button.WidthRequest != -1 ? button.WidthRequest : DEFAULT_WIDTH,
                button.HeightRequest > 30 ? button.HeightRequest : DEFAULT_HEIGHT);
            button.CornerRadius = button.CornerRadius > (int)(nButton.Frame.Height / 2) ? (int)nButton.Frame.Height / 2 : button.CornerRadius;
            nButton.Layer.CornerRadius = button.CornerRadius;
            nButton.SetTitle(button.Text, UIControlState.Normal);
            nButton.SetTitleColor(button.TextColor.ToUIColor(), UIControlState.Normal);
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
            // Gradient border
            nfloat borderWidth = (nfloat)button.BorderWidth;
            float width = (float)button.Width;
            float height = (float)button.Height;
            nButton.BackgroundColor = UIColor.Clear;
            nButton.Layer.BorderColor = UIColor.Clear.CGColor;
            nButton.Layer.BorderWidth = (nfloat)button.BorderWidth;
            var shape = new CAShapeLayer();
            shape.LineWidth = borderWidth;
            shape.Path =  UIBezierPath.FromRect(nButton.Bounds).CGPath;
            shape.StrokeColor = UIColor.Black.CGColor;
            shape.FillColor = UIColor.Clear.CGColor;
            var gradient = BackgroundExtension.CreateBackgroundGradientLayer(height,width, button.CornerRadius, button.StartColor.ToUIColor(),
                button.EndColor.ToUIColor(), button.CenterColor.ToUIColor(), button.Angle.ToiOS());
            gradient.Mask = shape;
            //Solid background
            CALayer cALayer = new CALayer();
            cALayer.BackgroundColor = button.BackgroundColor.ToCGColor();
            cALayer.Frame = new CGRect(borderWidth, borderWidth, width - borderWidth * 2, height - borderWidth * 2);
            nButton.Layer.AddSublayer(gradient);
            nButton.Layer.AddSublayer(cALayer);
        }
    }
}