using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace Skor.Controls.Droid.Extensions
{
    public static class ShadowExtension
    {
        public static Drawable CreateShadow(View view)
        {
            int elevationValue = 10;
            Rect shapeDrawablePadding = new Rect();
            shapeDrawablePadding.Left = elevationValue;
            shapeDrawablePadding.Right = elevationValue;
            shapeDrawablePadding.Top = elevationValue;
            shapeDrawablePadding.Bottom = elevationValue;
            int DY = 0;

            ShapeDrawable shapeDrawable = new ShapeDrawable();
            shapeDrawable.SetPadding(shapeDrawablePadding);


            shapeDrawable.Paint.Color = Color.Red;

            shapeDrawable.Paint.SetShadowLayer(12 / 3, 0, DY, Color.Red);



            view.SetLayerType(LayerType.Software, shapeDrawable.Paint);



            shapeDrawable.Shape = new RoundRectShape(new float[] { 12, 12, 12, 12, 12, 12, 12, 12 }, null, null);



            LayerDrawable drawable = new LayerDrawable(new Drawable[] { shapeDrawable });

            drawable.SetLayerInset(0, elevationValue, elevationValue * 2, elevationValue, elevationValue * 2);
            drawable.SetAlpha(40);


            return drawable;
        }
    }
}