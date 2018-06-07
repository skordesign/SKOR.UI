using Skor.Controls;
using Skor.Controls.Abstractions;
using Skor.Controls.UWP;
using Skor.Controls.UWP.Extensions;
using System;
using System.ComponentModel;
using System.IO;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(GradientButton), typeof(GradientButtonRenderer))]
namespace Skor.Controls.UWP
{
    public class GradientButtonRenderer : ViewRenderer<GradientButton, Button>
    {
        private const int DEFAULT_HEIGHT = 40;
        private const int DEFAULT_WIDTH = 100;
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
            nButton.Holding += (s, ev) => { ((IGradientButtonController)button).SendLongClick(); };
            SetNativeControl(nButton);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Height" || e.PropertyName == "Width" || e.PropertyName == "Image")
            {
                if (button.Image != null && !string.IsNullOrEmpty(button.Image.File))
                {
                    RenderImage();
                }
            }
        }
        private void RenderImage()
        {
            var grid = new Grid();
            var imageBrush = new ImageBrush();
            imageBrush.ImageSource = new BitmapImage(new System.Uri(this.BaseUri, $"/Assets/{button.Image.File}"));
            var rect = new Rectangle();
            rect.Width = button.Width > 0 ? button.Width : DEFAULT_WIDTH;
            rect.Height = button.Height > 0 ? button.Height : DEFAULT_HEIGHT;
            rect.Stretch = Stretch.Fill;
            rect.Fill = imageBrush;
            rect.Opacity = 0.2;
            grid.Children.Add(rect);
            grid.Children.Add(new TextBlock
            {
                Text = button.Text,
                Foreground = new SolidColorBrush(button.TextColor.ToWindows()),
                VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Center,
                HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center
            });
            nButton.Content = grid;
        }
        private void NButton_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            nButton.Background = BackgroundExtension.CreateGradientBrush(button.StartColor.ToWindows(),
                button.EndColor.ToWindows(),
                button.CenterColor.ToWindows(),
                button.Angle.ToWindows());
            if (button.Image != null && !string.IsNullOrEmpty(button.Image.File))
            {
                RenderImage();
            }
        }
    }
}
