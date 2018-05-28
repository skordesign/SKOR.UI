using Skor.Controls;
using Skor.Controls.Abstractions;
using Skor.Controls.UWP;
using Skor.Controls.UWP.Extensions;
using System;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace Skor.Controls.UWP
{
    public class GradientButtonRenderer: ViewRenderer<GradientButton, Button>
    {
        private GradientButton button;
        private Button nButton;
        protected override void OnElementChanged(ElementChangedEventArgs<GradientButton> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                button = e.NewElement;
            nButton = new Button
            {
                Content = button.Text,
                Foreground = new SolidColorBrush(button.TextColor.ToWindows()),
                BorderThickness = new Windows.UI.Xaml.Thickness(0, 0, 0, 0),
                Padding = new Windows.UI.Xaml.Thickness(0, 0, 0, 0)
            };
            nButton.Loaded += this.NButton_Loaded;
            nButton.Click += (s, ev) => { ((IGradientButtonController)button).SendClicked(); };
            nButton.Holding+= (s,ev)=> { ((IGradientButtonController)button).SendLongClick(); };
            SetNativeControl(nButton);
        }

        private void NButton_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new System.Uri(this.BaseUri,$"/Assets/{button.Image.File}"));
            var rect = new Rectangle();
            rect.Width = 100;
            rect.Height = 40;
            rect.Fill = imageBrush;
            rect.Opacity =0.4;
            nButton.Content = rect;
            nButton.Background = BackgroundExtension.CreateGradientBrush(button.StartColor.ToWindows(),
                button.EndColor.ToWindows(),
                button.CenterColor.ToWindows(),
                button.Angle.ToWindows());
        }
    }
}
