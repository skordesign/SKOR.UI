using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media;
namespace Skor.Controls.UWP.Extensions
{
    public static class BackgroundExtension
    {
        public static LinearGradientBrush CreateGradientBrush(Color startColor, Color endColor, Color centerColor,
           Point[] direction )
        {
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
            linearGradientBrush.StartPoint = direction[0];
            linearGradientBrush.EndPoint = direction[1];
            var gradients = new GradientStopCollection
            {
                new GradientStop() { Color = startColor, Offset = 0 }
            };
            if (centerColor != Xamarin.Forms.Color.Transparent.ToWindows())
                gradients.Add(new GradientStop { Color = centerColor, Offset = 0.5 });
            gradients.Add(new GradientStop { Color = endColor, Offset = 1 });
            linearGradientBrush.GradientStops = gradients;
            return linearGradientBrush;
        }
    }
}
