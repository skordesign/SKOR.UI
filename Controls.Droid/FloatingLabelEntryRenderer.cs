using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(global::Skor.Controls.FloatingLabelEntry), typeof(global::Skor.Controls.Droid.FloatingLabelEntryRenderer))]
namespace Skor.Controls.Droid
{
    public class FloatingLabelEntryRenderer : ViewRenderer<FloatingLabelEntry, TextInputLayout>
    {
        private FloatingLabelEntry entry;
        private TextInputLayout layout;
        private AppCompatEditText editText;
        public FloatingLabelEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<FloatingLabelEntry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                entry = e.NewElement;
            InitControls();

            SetNativeControl(layout);
        }
        void InitControls()
        {
            var font = Font.OfSize(entry.FontFamily, entry.FontSize);
            font.WithAttributes(entry.FontAttributes);
            layout = new TextInputLayout(Context);
            layout.LayoutParameters = new LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            layout.Hint = entry.Placeholder;
            layout.Typeface = font.ToTypeface();

            editText = new AppCompatEditText(Context);
            var editTextParams = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.WrapContent);
            editText.LayoutParameters = editTextParams;
            editText.Typeface = font.ToTypeface();
            editText.SetTextColor(entry.TextColor.ToAndroid());
            layout.AddView(editText);
            SetInputTextLayoutColor(layout, entry.LabelColor.ToAndroid());
        }
        private ColorStateList CreateColorStateListForEditText() =>
             new ColorStateList(new int[][] {
                 //States
             new int[] { Android.Resource.Attribute.StateFocused },
             new int[] { -Android.Resource.Attribute.StateEnabled  },
             new int[] { -Android.Resource.Attribute.StateFirst } },
             //Colors
             new int[] { entry.FocusColor.ToAndroid(),
                 entry.DisabledColor.ToAndroid(),
                 entry.BackgroundColor.ToAndroid() });

        public void SetInputTextLayoutColor(TextInputLayout til, Android.Graphics.Color color)
        {
            try
            {
                Java.Lang.Reflect.Field fDefaultTextColor = Java.Lang.Class.FromType(typeof(TextInputLayout)).GetDeclaredField("mDefaultTextColor");
                fDefaultTextColor.Accessible = true;
                fDefaultTextColor.Set(til, new ColorStateList(new int[][] { new int[] { 0 } }, new int[] { entry.PlaceholderColor.ToAndroid() }));

                Java.Lang.Reflect.Field fFocusedTextColor = Java.Lang.Class.FromType(typeof(TextInputLayout)).GetDeclaredField("mFocusedTextColor");
                fFocusedTextColor.Accessible = true;
                fFocusedTextColor.Set(til, new ColorStateList(new int[][] { new int[] { 0 } }, new int[] { entry.TextColor.ToAndroid() }));
            }
            catch
            {
            }
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == nameof(entry.Height) || e.PropertyName == nameof(entry.Width))
            {
                if (entry.Icon != default(FileImageSource))
                {
                    //SetIcon();
                }
            }
        }
        private void SetIcon()
        {

        }
        void InitStyles()
        {

        }
        private Drawable CreateBackground()
        {
            var normalDrawable = BackgroundExtension.CreateBackgroundColor(entry.BackgroundColor.ToAndroid(), (float)entry.CornerRadius);
            var focusDrawable = BackgroundExtension.CreateBackgroundColor(entry.FocusColor.ToAndroid(), (float)entry.CornerRadius);
            var disabledDrawable = BackgroundExtension.CreateBackgroundColor(entry.DisabledColor.ToAndroid(), (float)entry.CornerRadius);
            var statesListDrawable = new StateListDrawable();
            statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StateFocused }, focusDrawable);
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, disabledDrawable);
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateFirst }, normalDrawable);
            return new InsetDrawable(statesListDrawable, 0, 4, 0, 0);
        }
    }
}