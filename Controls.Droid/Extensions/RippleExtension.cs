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
            ColorStateList colorStateList = new ColorStateList(
                new int[][]
                {
                    new int[]{ Android.Resource.Attribute.StatePressed }
                }, new int[] { rippleColor }
                );
            RippleDrawable rippleDrawable = new RippleDrawable(colorStateList, background, background);
            view.Background = rippleDrawable;
        }
        public static void SetAllParentsClip(this View view, bool enabled)
        {
            while (view.Parent != null && view.Parent is ViewGroup parent)
            {
                parent.SetClipChildren(enabled);
                parent.SetClipToPadding(enabled);
                parent.LayoutMode = ViewLayoutMode.OpticalBounds;
                parent.SetPadding(10, 10, 10, 10);
                view = parent;
            }
        }
    }
}