using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Skor.Controls;
using Skor.Controls.UWP;
using Skor.Controls.UWP.Extensions;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace Skor.Controls.UWP
{
    public class GradientButtonRenderer: ViewRenderer<GradientButton, Windows.UI.Xaml.Controls.Button>
    {
        private GradientButton button;
        private Button nButton;
        protected override void OnElementChanged(ElementChangedEventArgs<GradientButton> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                button = e.NewElement;
            nButton = new Button();
            nButton.Content = button.Text;
            nButton.Foreground = new SolidColorBrush(button.TextColor.ToWindows());
            nButton.Loaded += this.NButton_Loaded;
            nButton.BorderThickness = new Windows.UI.Xaml.Thickness(0,0,0,0);
            SetNativeControl(nButton);
        }

        private void NButton_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            nButton.Background = BackgroundExtension.CreateGradientBrush(button.StartColor.ToWindows(),
                button.EndColor.ToWindows(),
                button.CenterColor.ToWindows(),
                button.Angle.ToWindows());
        }
    }
}
