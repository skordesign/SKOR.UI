using Android.Content;
using Skor.Controls;
using Skor.Controls.Droid;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(GradientFrame), typeof(GradientFrameRenderer))]
namespace Skor.Controls.Droid
{
    public class GradientFrameRenderer : Xamarin.Forms.Platform.Android.AppCompat.FrameRenderer
    {
        private GradientFrame grid;
        public GradientFrameRenderer(Context context) : base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                grid = e.NewElement as GradientFrame;
                Control.Background = BackgroundExtension.CreateBackgroundGradient(grid.StartColor.ToAndroid(),
                    grid.EndColor.ToAndroid(),
                    grid.CenterColor.ToAndroid(),
                    0, grid.Angle.ToAndroid());
            }
        }
    }
}