using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using Skor.Controls;
using Skor.Controls.iOS;
using Skor.Controls.iOS.Extensions;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientToggleButton), typeof(GradientToggleButtonRenderer))]
namespace Skor.Controls.iOS
{
    public class GradientToggleButtonRenderer: ViewRenderer<GradientToggleButton, UIButton>
    {
        private const float DEFAULT_HEIGHT = 30;
        private const float DEFAULT_WIDTH = 100;
        private GradientToggleButton button;
        private UIButton nButton;
        protected override void OnElementChanged(ElementChangedEventArgs<GradientToggleButton> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null) return;

            button = e.NewElement as GradientToggleButton;
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
            SetNativeControl(nButton);
        }
        void Handler(object sender, EventArgs e)
        {
            button.SendToggle();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(button.Width) || e.PropertyName == nameof(button.Height)|| e.PropertyName == nameof(button.IsToggled))
            {
                CreateBackground();
            }
        }
        void CreateBackground()
        {
            if (button.IsToggled)
            {
                CreateToggleBackground();
            }
            else
            {
                CreateUnToggleBackground();
            }
        }
        void CreateToggleBackground()
        {
            nButton.BackgroundColor = UIColor.Clear;
            nButton.Layer.BorderColor = UIColor.Clear.CGColor;
            nButton.Layer.BorderWidth = 0;
            nButton.Layer.Sublayers = null;
            nButton.Layer.InsertSublayer(BackgroundExtension.CreateBackgroundGradientLayer((float)button.Height, (float)button.Width, button.CornerRadius, button.ToggleStartColor.ToUIColor(),
                button.ToggleEndColor.ToUIColor(), button.ToggleCenterColor.ToUIColor(), button.Angle.ToiOS()), 0);
            if (button.Image != null && button.Image.File.Length > 0)
            {
                var background = BackgroundExtension.CreateBackgroundImage((float)button.Height, (float)button.Width, button.CornerRadius, button.Image.File);
                nButton.Layer.InsertSublayer(background, 1);
            }
        }
        void CreateUnToggleBackground()
        {
            nButton.BackgroundColor = UIColor.Clear;
            nButton.Layer.BorderColor = UIColor.Clear.CGColor;
            nButton.Layer.BorderWidth = 0;
            nButton.Layer.Sublayers = null;
            nButton.Layer.InsertSublayer(BackgroundExtension.CreateBackgroundGradientLayer((float)button.Height, (float)button.Width, button.CornerRadius, button.StartColor.ToUIColor(),
                button.EndColor.ToUIColor(), button.CenterColor.ToUIColor(), button.Angle.ToiOS()), 0);
        }
    }
}