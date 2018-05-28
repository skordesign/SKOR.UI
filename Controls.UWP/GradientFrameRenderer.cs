using Skor.Controls;
using Skor.Controls.UWP;
using Skor.Controls.UWP.Extensions;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(GradientFrame), typeof(GradientFrameRenderer))]
namespace Skor.Controls.UWP
{
    public class GradientFrameRenderer: FrameRenderer
    {
        private Border border;
        private GradientFrame frame;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                frame = e.NewElement as GradientFrame;
            }
            if (Control != null)
            {
                border = Control;
                border.Loaded += this.Border_Loaded;
            }
        }

        private void Border_Loaded(object sender, RoutedEventArgs e)
        {
           border.Background =  BackgroundExtension.CreateGradientBrush(frame.StartColor.ToWindows(),
                frame.EndColor.ToWindows(),
                frame.CenterColor.ToWindows(),
                frame.Angle.ToWindows());
            border.CornerRadius = frame.CornerRadius > 0 ? new CornerRadius(frame.CornerRadius) : new CornerRadius(0);
        }
    }
}
