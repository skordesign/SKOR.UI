using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace Skor.Controls.Droid
{
    public class ClassicEntryRenderer: EntryRenderer
    {
        private ClassicEntry classicEntry;
        public ClassicEntryRenderer(Context context):base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                classicEntry = e.NewElement as ClassicEntry;
            Control.Background = CreateBackground();
        }

        private Drawable CreateBackground()
        {
            var normalDrawable = BackgroundExtension.CreateBackgroundGradient(classicEntry.BackgroundColor.ToAndroid(),
                classicEntry.BackgroundColor.ToAndroid(),
                classicEntry.BackgroundColor.ToAndroid(),
                (float)classicEntry.CornerRadius,
                GradientDrawable.Orientation.BlTr);
            var statesListDrawable = new StateListDrawable();
            //statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, layerDisabled);
            //statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StatePressed }, layer);
            //statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StateEnabled }, layer);
            return statesListDrawable;
        }
    }
}