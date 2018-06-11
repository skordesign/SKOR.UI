using Skor.Controls;
using Skor.Controls.UWP;
using Skor.Controls.UWP.Extensions;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Shapes;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(GradientToggleButton), typeof(GradientToggleButtonRenderer))]
namespace Skor.Controls.UWP
{
    public class GradientToggleButtonRenderer:ViewRenderer<GradientToggleButton, Button>
    {
        private const int DEFAULT_HEIGHT = 40;
        private const int DEFAULT_WIDTH = 100;
        private GradientToggleButton button;
        private Button nButton;
        protected override void OnElementChanged(ElementChangedEventArgs<GradientToggleButton> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                button = e.NewElement;
            nButton = new Button
            {
                Content = button.Text,
                Foreground = new SolidColorBrush(button.TextColor.ToWindows()),
                BorderThickness = new Thickness(0, 0, 0, 0),
                Padding = new Thickness(0, 0, 0, 0),
                Style = Application.Current.Resources["ButtonRevealStyle"] as Style
            };
            nButton.Loaded += this.NButton_Loaded;
            nButton.Click += (s, ev) => { button.SendToggle(); };
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
            if(e.PropertyName == nameof(button.IsToggled))
            {
                CreateBackgroundForButton();
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
        void RenderContent()
        {
            var grid = new Grid();
            var rect = new Rectangle();
            rect.Width = button.Width > 0 ? button.Width : DEFAULT_WIDTH;
            rect.Height = button.Height > 0 ? button.Height : DEFAULT_HEIGHT;
            rect.Stretch = Stretch.Fill;
            rect.Opacity = 0;
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
        }
        void CreateBackgroundForButton()
        {
            if (button.IsToggled)
            {
                nButton.Background = CreateBackgroundToggle();
                if (button.Image != null && !string.IsNullOrEmpty(button.Image.File))
                {
                    RenderImage();
                }
            }
            else
            {
                nButton.Background = CreateBackgroundUnToggle();
                RenderContent();
            }
        }
        Brush CreateBackgroundToggle()
        {
            return BackgroundExtension.CreateGradientBrush(button.ToggleStartColor.ToWindows(),
                button.ToggleEndColor.ToWindows(),
                button.ToggleCenterColor.ToWindows(),
                button.Angle.ToWindows());
        }
        Brush CreateBackgroundUnToggle()
        {
            return BackgroundExtension.CreateGradientBrush(button.StartColor.ToWindows(),
                button.EndColor.ToWindows(),
                button.CenterColor.ToWindows(),
                button.Angle.ToWindows());
        }
    }
}
