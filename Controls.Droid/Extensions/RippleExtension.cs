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

namespace Skor.Controls.Droid.Extensions
{
    public static class RippleExtension
    {
        /// <summary>
        /// Add ripple to exist view
        /// </summary>
        /// <param name="view"></param>
        /// <param name="rippleColor"></param>
        public static void AddRipple(this View view, Color rippleColor)
        {
            var background = view.Background;
            RippleDrawable rippleDrawable = new RippleDrawable(ColorStateList.ValueOf(rippleColor), background, background);
            view.Background = rippleDrawable;
        }
    }
}