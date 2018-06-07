using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Android.Animation;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Support.V4.View;
using Android.Widget;
using Skor.Controls.Abstractions;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(global::Skor.Controls.GradientButton), typeof(global::Skor.Controls.Droid.GradientButtonRenderer))]
namespace Skor.Controls.Droid
{
    public class GradientButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<global::Skor.Controls.GradientButton, FrameLayout>
    {
        private const int DEFAULT_HEIGHT_BUTTON = 96;
        private Android.Support.V7.Widget.AppCompatButton nButton;
        private global::Skor.Controls.GradientButton button;
        private FrameLayout frame;
        public GradientButtonRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<global::Skor.Controls.GradientButton> e)
        {
            base.OnElementChanged(e);
            this.button = e.NewElement as global::Skor.Controls.GradientButton;
            this.button.HeightRequest = this.button.HeightRequest != -1 ? this.button.HeightRequest : DEFAULT_HEIGHT_BUTTON;
            InitControls();
            InitStyleButton();
            nButton.Click += (s, ev) =>
            {
                ((IGradientButtonController)button).SendClicked();
            };
            nButton.LongClick += (s, ev) =>
            {
                ((IGradientButtonController)button).SendLongClick();
            };
            frame.AddView(nButton);
            SetNativeControl(this.frame);
        }
        void InitControls()
        {
            //Layout
            frame = new FrameLayout(Context);
            frame.LayoutParameters = new FrameLayout.LayoutParams((int)button.WidthRequest, (int)button.HeightRequest);
            nButton = new Android.Support.V7.Widget.AppCompatButton(Context);
            //Button
            var nBtnLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nBtnLayout.SetMargins(24, 0, 24, 36);
            nButton.LayoutParameters = nBtnLayout;
        }

        private void InitStyleButton()
        {
            nButton.Text = button.Text;
            nButton.SetTextColor(button.TextColor.ToAndroid());

            nButton.Background = CreateBackgroundForButton();
            nButton.AddRipple(Android.Graphics.Color.White);
            nButton.Enabled = button.IsEnabled;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "IsEnabled")
            {
                if (e.PropertyName == "IsEnabled")
                {
                    nButton.Enabled = button.IsEnabled;
                }
            }
        }
        Drawable CreateBackgroundForButton()
        {
            List<Drawable> drawables = new List<Drawable>();
            List<Drawable> drawablesDisabled = new List<Drawable>();
            drawables.Add(BackgroundExtension.CreateBackgroundGradient(button.StartColor.ToAndroid(),
                button.EndColor.ToAndroid(),
                button.CenterColor.ToAndroid(),
                button.CornerRadius,
                button.Angle.ToAndroid()));
            drawablesDisabled.Add(BackgroundExtension.CreateBackgroundGradient(button.StartColor.ToAndroid(),
                button.EndColor.ToAndroid(),
                button.CenterColor.ToAndroid(),
                button.CornerRadius,
                button.Angle.ToAndroid()));
            if (button.Image != null && !string.IsNullOrEmpty(button.Image.File))
            {
                var bitmapDrawable = BackgroundExtension.CreateBackgroundBitmap(button.Image.File, (int)button.HeightRequest,
                    (int)button.WidthRequest, button.CornerRadius);
                if (bitmapDrawable != null)
                {
                    drawables.Add(bitmapDrawable);
                    drawablesDisabled.Add(bitmapDrawable);
                }
            }
            Drawable layer = new LayerDrawable(drawables.ToArray());
            Drawable layerDisabled = new LayerDrawable(drawablesDisabled.ToArray());
            layerDisabled.Mutate().Alpha = 80;
            var statesListDrawable = new StateListDrawable();
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, layerDisabled);
            statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StatePressed }, layer);
            statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StateEnabled }, layer);
            return statesListDrawable;
        }
    }
}