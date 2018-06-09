using Skor.Controls;
using Skor.Controls.Abstractions;
using Skor.Controls.UWP;
using Skor.Controls.UWP.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(GradientTextButton), typeof(GradientTextButtonRenderer))]
namespace Skor.Controls.UWP
{
    public class GradientTextButtonRenderer : ViewRenderer<GradientTextButton, Button>
    {
        private const int DEFAULT_HEIGHT = 40;
        private const int DEFAULT_WIDTH = 100;
        private GradientTextButton button;
        private Button nButton;
        protected override void OnElementChanged(ElementChangedEventArgs<GradientTextButton> e)
        {
            //base.OnElementChanged(e);
            if (e.NewElement != null)
                button = e.NewElement;
            var linear = BackgroundExtension.CreateGradientBrush(button.StartColor.ToWindows(),
                button.EndColor.ToWindows(),
                button.CenterColor.ToWindows(),
                button.Angle.ToWindows());
            nButton = new Button
            {
                Content = button.Text,
                Background = new SolidColorBrush(button.BackgroundColor.ToWindows()),
                Foreground = linear,
                BorderBrush = linear,
                BorderThickness = new Thickness(button.BorderWidth),
                Style = Application.Current.Resources["ButtonRevealStyle"] as Style
            };
            nButton.Click += (s, ev) => { button.SendClicked(); };
            nButton.Holding += (s, ev) => { button.SendLongClick(); };
            SetNativeControl(nButton);
        }
    }
}
