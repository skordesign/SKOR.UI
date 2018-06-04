using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Graphics.Drawable;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using static Android.Graphics.Shader;

namespace Skor.Controls.Droid.Extensions
{
    public static class BackgroundExtension
    {
        public static LinearGradient CreateLinearGradient(Color startColor, Color endColor, Color centerColor, float width, float height)
        {
            return new LinearGradient(0, height/2, width, height/2,
                new int[] { startColor, centerColor, endColor },
                null,
                TileMode.Mirror
                );
        }
        public static Drawable CreateBackgroundGradient(Color startColor, Color endColor, Color centerColor,
            float cornerRadius, GradientDrawable.Orientation orientation)
        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            gradientDrawable.SetShape(ShapeType.Rectangle);
            gradientDrawable.SetCornerRadius(cornerRadius);
            if (centerColor != Xamarin.Forms.Color.Transparent.ToAndroid())
            {
                gradientDrawable.SetColors(new int[] { startColor,
                centerColor,endColor});
            }
            else
            {
                gradientDrawable.SetColors(new int[] { startColor, endColor });
            }
            gradientDrawable.SetGradientType(GradientType.LinearGradient);
            gradientDrawable.SetOrientation(orientation);
            return gradientDrawable;
        }
        public static void SetBackgroundGradientForButton(this View view, global::Skor.Controls.GradientButton button)
        {
            GradientDrawable gradientDrawable = new GradientDrawable();
            gradientDrawable.SetShape(ShapeType.Rectangle);
            gradientDrawable.SetCornerRadius(button.CornerRadius);
            if (button.CenterColor != Xamarin.Forms.Color.Transparent)
            {
                gradientDrawable.SetColors(new int[] { button.StartColor.ToAndroid(),
                button.CenterColor.ToAndroid(),button.EndColor.ToAndroid() });
            }
            else
            {
                gradientDrawable.SetColors(new int[] {
                        button.StartColor.ToAndroid(),button.EndColor.ToAndroid()});
            }
            gradientDrawable.SetGradientType(GradientType.LinearGradient);
            gradientDrawable.SetOrientation(button.Angle.ToAndroid());
            view.Background = gradientDrawable;
        }
        /// <summary>
        /// Not working yet
        /// </summary>
        /// <param name="view"></param>
        /// <param name="button"></param>
        public static void SetBitmapToButton(this View view, global::Skor.Controls.GradientButton button)
        {
            if (button.Image != null && !string.IsNullOrEmpty(button.Image.File))
            {
                var bitmap = Application.Context.Resources.GetBitmap(button.Image);
                if (bitmap != null)
                {
                    int height = (int)button.HeightRequest;
                    int width = (int)(bitmap.Width * height / bitmap.Height);
                    bitmap = Bitmap.CreateScaledBitmap(bitmap, width, height, false);
                    var bg = view.Background;
                    var dr = RoundedBitmapDrawableFactory.Create(Application.Context.Resources, bitmap);
                    dr.CornerRadius = ((GradientDrawable)bg).CornerRadius;
                    dr.SetAlpha(40);

                    Drawable[] drawables = new Drawable[] { bg, dr };
                    LayerDrawable layer = new LayerDrawable(drawables);
                    view.Background = layer;
                }
            }
        }
        public static Drawable AddBitmapToView(View view, string image, int height, int width)
        {
            var bitmap = Application.Context.Resources.GetBitmap(image);
            if (bitmap != null)
            {
                bitmap = Bitmap.CreateScaledBitmap(bitmap, width, height, false);
                var bg = view.Background;
                var dr = RoundedBitmapDrawableFactory.Create(Application.Context.Resources, bitmap);
                dr.CornerRadius = ((GradientDrawable)bg).CornerRadius;
                dr.SetAlpha(40);
                return dr;
            }
            return null;
        }
    }
}