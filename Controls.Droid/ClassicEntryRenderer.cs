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
[assembly: ExportRenderer(typeof(global::Skor.Controls.ClassicEntry), typeof(global::Skor.Controls.Droid.ClassicEntryRenderer))]
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
            InitStyles();
        }
        void InitStyles()
        {
            Control.SetPadding(Control.PaddingStart + (int)classicEntry.CornerRadius, Control.PaddingTop, Control.PaddingEnd + (int)classicEntry.CornerRadius, Control.PaddingBottom);
            Control.Hint = classicEntry.Placeholder;
            Control.SetHintTextColor(classicEntry.PlaceholderColor.ToAndroid());
        }
        private Drawable CreateBackground()
        {
            var normalDrawable = BackgroundExtension.CreateBackgroundColor(classicEntry.BackgroundColor.ToAndroid(), (float)classicEntry.CornerRadius);
            var focusDrawable = BackgroundExtension.CreateBackgroundColor(classicEntry.FocusColor.ToAndroid(), (float)classicEntry.CornerRadius);
            var disabledDrawable = BackgroundExtension.CreateBackgroundColor(classicEntry.DisabledColor.ToAndroid(), (float)classicEntry.CornerRadius);
            var statesListDrawable = new StateListDrawable();
            statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StateFocused }, focusDrawable);
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, disabledDrawable);
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateFirst }, normalDrawable);
            return statesListDrawable;
        }
    }
}