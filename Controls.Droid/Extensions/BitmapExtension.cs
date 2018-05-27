using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Renderscripts;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Skor.Controls.Droid.Extensions
{
    public static class BitmapExtension
    {
        private const float BITMAP_SCALE = 0.4f;

        //Set the radius of the Blur. Supported range 0 < radius <= 25
        private static float BLUR_RADIUS = 10.5f;

        public static Bitmap Blur(this Bitmap image, Context context, float blurRadius=25)
        {
            Bitmap outputBitmap = null;
            if (image != null)
            {

                if (blurRadius == 0)
                {
                    return image;
                }

                if (blurRadius < 1)
                {
                    blurRadius = 1;
                }

                if (blurRadius > 25)
                {
                    blurRadius = 25;
                }

                BLUR_RADIUS = blurRadius;

                int width = (int)Math.Round(image.Width * BITMAP_SCALE);
                int height = (int)Math.Round(image.Width * BITMAP_SCALE);

                Bitmap inputBitmap = Bitmap.CreateScaledBitmap(image, width, height, false);
                outputBitmap = Bitmap.CreateBitmap(inputBitmap);

                RenderScript rs = RenderScript.Create(context);
                ScriptIntrinsicBlur theIntrinsic = ScriptIntrinsicBlur.Create(rs, Element.U8_4(rs));
                Allocation tmpIn = Allocation.CreateFromBitmap(rs, inputBitmap);
                Allocation tmpOut = Allocation.CreateFromBitmap(rs, outputBitmap);
                theIntrinsic.SetRadius(BLUR_RADIUS);
                theIntrinsic.SetInput(tmpIn);
                theIntrinsic.ForEach(tmpOut);
                tmpOut.CopyTo(outputBitmap);
            }
            return outputBitmap;
        }
    }
}