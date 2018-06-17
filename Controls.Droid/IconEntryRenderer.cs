using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(global::Skor.Controls.IconEntry), typeof(global::Skor.Controls.Droid.IconEntryRenderer))]
namespace Skor.Controls.Droid
{
    public class IconEntryRenderer: EntryRenderer
    {
        public IconEntryRenderer(Context context):base(context)
        {

        }
        private IconEntry iconEntry;
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                iconEntry = e.NewElement as IconEntry;
            Control.Background = CreateBackground();
            InitStyles();
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName==nameof(iconEntry.Height) || e.PropertyName == nameof(iconEntry.Width))
            {
                if (iconEntry.Icon != default(FileImageSource))
                {
                    SetIcon();
                }
            }
        }
        private void SetIcon()
        {
            var bitmap = Android.App.Application.Context.Resources.GetBitmap(iconEntry.Icon);
            if (bitmap != null)
            {
                Drawable bitmapDrawble = new BitmapDrawable(Bitmap.CreateScaledBitmap(bitmap, GetPixel((int)iconEntry.Height),GetPixel((int)iconEntry.Height),true));
                var insetDrawble = new InsetDrawable(bitmapDrawble,8);
                Control.SetCompoundDrawablesRelativeWithIntrinsicBounds(insetDrawble, null, null, null);
            }
        }
        private int GetPixel(int dp)
        {
            return (int)TypedValue.ApplyDimension(ComplexUnitType.Mm, dp,Context.Resources.DisplayMetrics);
        }
        void InitStyles()
        {
            Control.SetPadding(Control.PaddingStart + (int)iconEntry.CornerRadius, Control.PaddingTop, Control.PaddingEnd + (int)iconEntry.CornerRadius, Control.PaddingBottom);
            Control.Hint = iconEntry.Placeholder;
            Control.SetHintTextColor(iconEntry.PlaceholderColor.ToAndroid());
        }
        private Drawable CreateBackground()
        {
            var normalDrawable = BackgroundExtension.CreateBackgroundColor(iconEntry.BackgroundColor.ToAndroid(), (float)iconEntry.CornerRadius);
            var focusDrawable = BackgroundExtension.CreateBackgroundColor(iconEntry.FocusColor.ToAndroid(), (float)iconEntry.CornerRadius);
            var disabledDrawable = BackgroundExtension.CreateBackgroundColor(iconEntry.DisabledColor.ToAndroid(), (float)iconEntry.CornerRadius);
            var statesListDrawable = new StateListDrawable();
            statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StateFocused }, focusDrawable);
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, disabledDrawable);
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateFirst }, normalDrawable);
            return statesListDrawable;
        }
    }
}