using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using Skor.Controls;
using Skor.Controls.Abstractions;
using Skor.Controls.iOS;
using Skor.Controls.iOS.Extensions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace Skor.Controls.iOS
{
    public class GradientButtonRenderer : ViewRenderer<GradientButton, UIButton>
    {
        private const float DEFAULT_HEIGHT = 30;
        private const float DEFAULT_WIDTH = 100;
        private GradientButton button;
        private UIButton nButton;
        protected override void OnElementChanged(ElementChangedEventArgs<GradientButton> e)
        {
            base.OnElementChanged(e);
            button = e.NewElement as GradientButton;
            nButton = new UIButton(UIButtonType.System);
            nButton.TranslatesAutoresizingMaskIntoConstraints = true;
            nButton.Frame = new CGRect(0, 0, button.WidthRequest!=-1?button.WidthRequest:DEFAULT_WIDTH, 
                button.HeightRequest>30?button.HeightRequest:DEFAULT_HEIGHT);
            button.CornerRadius = button.CornerRadius > (float)(nButton.Frame.Height / 2) ? (float)nButton.Frame.Height / 2 : button.CornerRadius;
            nButton.Layer.CornerRadius =  button.CornerRadius ;
            nButton.SetTitle(button.Text, UIControlState.Normal);
            nButton.SetTitleColor(button.TextColor.ToUIColor(), UIControlState.Normal);
            nButton.Layer.MasksToBounds = true;
            nButton.TouchUpInside += Handler;
            var longPress = new UILongPressGestureRecognizer();
            longPress.AddTarget(() => ((IGradientButtonController)button).SendLongClick());
            nButton.GestureRecognizers = new UIGestureRecognizer[] { longPress };
            SetNativeControl(nButton);
        }
        void Handler(object sender, EventArgs e)
        {
            ((IGradientButtonController)button).SendClicked();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Width" || e.PropertyName == "Height")
            {
                nButton.BackgroundColor = UIColor.Clear;
                nButton.Layer.BorderColor = UIColor.Clear.CGColor;
                nButton.Layer.BorderWidth = 0;
                nButton.Layer.InsertSublayer(BackgroundExtension.CreateBackgroundGradientLayer((float)button.Height, (float)button.Width, button.CornerRadius, button.StartColor.ToUIColor(),
                    button.EndColor.ToUIColor(), button.CenterColor.ToUIColor(), button.Angle.ToiOS()), 0);
                if(button.Image!=null && button.Image.File.Length > 0)
                {
                    var background = BackgroundExtension.CreateBackgroundImage((float)button.Height, (float)button.Width, button.CornerRadius, button.Image.File);
                    nButton.Layer.InsertSublayer(background, 1);
                }
            }
        }
    }
}