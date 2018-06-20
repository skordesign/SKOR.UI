using Android.Content;
using Android.Graphics.Drawables;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(global::Skor.Controls.ClassicEntry), typeof(global::Skor.Controls.Droid.ClassicEntryRenderer))]
namespace Skor.Controls.Droid
{
    public class ClassicEntryRenderer: EntryRenderer
    {
        private ClassicEntry entry;
        public ClassicEntryRenderer(Context context):base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
                entry = e.NewElement as ClassicEntry;
            Control.Background = CreateBackground();
            InitStyles();
        }
        void InitStyles()
        {
            Control.SetPadding(Control.PaddingStart + (int)entry.CornerRadius, Control.PaddingTop, Control.PaddingEnd + (int)entry.CornerRadius, Control.PaddingBottom);
            Control.Hint = entry.Placeholder;
            var font =  Font.OfSize(entry.FontFamily, entry.FontSize);
            font.WithAttributes(entry.FontAttributes);
            Control.Typeface = font.ToTypeface();
            Control.SetHintTextColor(entry.PlaceholderColor.ToAndroid());
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
            return statesListDrawable;
        }
    }
}