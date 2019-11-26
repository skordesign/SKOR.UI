using Android.Content;
using Android.Graphics.Drawables;
using Skor.Controls;
using Skor.Controls.Droid;
using Skor.Controls.Droid.Extensions;
using System.Collections.Generic;
using System.ComponentModel;
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
            if (Control != null && e.NewElement != null)
            {
                grid = e.NewElement as GradientFrame;
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "Width" || e.PropertyName == "Height")
                Control.Background = CreateBackgroundFrame();
        }
        private Drawable CreateBackgroundFrame()
        {
            List<Drawable> drawables = new List<Drawable>();
            var layer1 = BackgroundExtension.CreateBackgroundGradient(grid.StartColor.ToAndroid(),
                grid.EndColor.ToAndroid(),
                grid.CenterColor.ToAndroid(), grid.CornerRadius, grid.Angle.ToAndroid());
            drawables.Add(layer1);
            if (grid.Image != null && !string.IsNullOrEmpty(grid.Image.File))
            {
                var bitmapDrawable = BackgroundExtension.CreateBackgroundBitmap(grid.Image.File, (int)grid.Height,
                    (int)grid.Width, grid.CornerRadius);
                if (bitmapDrawable != null)
                {
                    drawables.Add(bitmapDrawable);
                }
            }
            return new LayerDrawable(drawables.ToArray());
        }
    }
}