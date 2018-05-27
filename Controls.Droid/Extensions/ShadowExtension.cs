using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace Skor.Controls.Droid.Extensions
{
    public static class ShadowExtension
    {
        //shadow not working yet
        public static void AddShadowToButton(this View view, GradientButton button)
        {
            var background = view.Background;
            var gradient = new GradientDrawable
            {
                Alpha = 20
            };
            gradient.SetShape(ShapeType.Rectangle);
            gradient.SetCornerRadius(button.CornerRadius);
            gradient.SetSize(view.Width - 5, view.Height - 5);
            gradient.SetColors(new int[] { button.EndColor.ToAndroid(),
                        button.StartColor.ToAndroid()});
            gradient.Bounds.Bottom = -2;
            gradient.Bounds.Right = -2;
            gradient.SetStroke(2, Color.Black);
            Drawable[] drawables = new Drawable[] { background, gradient };
            LayerDrawable layer = new LayerDrawable(drawables);
            //layer.SetLayerInset(1, 0, 0, 0, -50);
            view.Background = layer;
        }
        public static Drawable AddShadowToButton(global::Skor.Controls.GradientButton btn=null, bool click=false)
        {
            var gradient = new GradientDrawable
            {
                Alpha = 40
            };
            gradient.SetShape(ShapeType.Rectangle);
            gradient.SetGradientType(GradientType.RadialGradient);
            gradient.SetOrientation(GradientDrawable.Orientation.TopBottom);
            gradient.SetCornerRadius(btn.CornerRadius+4);
            gradient.SetColors(new int[] { btn.StartColor.ToAndroid(), Color.Gray});
            //gradient.SetGradientRadius(400);
            return gradient;
        }
    }
}