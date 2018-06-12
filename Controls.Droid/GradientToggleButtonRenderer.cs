using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(global::Skor.Controls.GradientToggleButton), typeof(global::Skor.Controls.Droid.GradientToggleButtonRenderer))]
namespace Skor.Controls.Droid
{
    public class GradientToggleButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<global::Skor.Controls.GradientToggleButton, FrameLayout>
    {
        private const int DEFAULT_HEIGHT_BUTTON = 56;
        private Android.Support.V7.Widget.AppCompatButton nButton;
        private global::Skor.Controls.GradientToggleButton button;
        private FrameLayout frame;
        private bool isToggle = false;
        public bool IsToggle
        {
            get => isToggle;
            set {
                isToggle = value;
                nButton.Background = CreateBackgroundForButton();
                RenderText();
            }
        }
        public GradientToggleButtonRenderer(Context context):base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<global::Skor.Controls.GradientToggleButton> e)
        {
            base.OnElementChanged(e);
            this.button = e.NewElement as global::Skor.Controls.GradientToggleButton;
            this.button.HeightRequest = this.button.HeightRequest >= DEFAULT_HEIGHT_BUTTON ? this.button.HeightRequest : DEFAULT_HEIGHT_BUTTON;
            InitControls();
            RenderText();
            InitStyleButton();
            nButton.Click += (s, ev) =>
            {
                button.SendToggle();
            };
            frame.AddView(nButton);
            SetNativeControl(this.frame);
        }
        void InitControls()
        {
            //Layout
            frame = new FrameLayout(Context);
            frame.LayoutParameters = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nButton = new Android.Support.V7.Widget.AppCompatButton(Context);
            //Button
            var nBtnLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nBtnLayout.SetMargins(8, 8, 8, 24);
            nButton.SetPadding(0, 0, 0, 0);
            nButton.LayoutParameters = nBtnLayout;
        }

        private void InitStyleButton()
        {
            nButton.Background = CreateBackgroundForButton();
            nButton.AddRipple(button.RippleColor.ToAndroid());
            nButton.Enabled = button.IsEnabled;
            if (!button.HasShadow)
            {
                nButton.StateListAnimator = null;
            }
        }
        private void RenderText()
        {
            nButton.Text = button.Text;
            nButton.Typeface = button.Font.ToTypeface();
            if (button.IsToggled)
            {
                nButton.SetTextColor(button.ToggleTextColor.ToAndroid());
            }
            else
            {
                nButton.SetTextColor(button.TextColor.IsDefault ? Android.Graphics.Color.Black : button.TextColor.ToAndroid());
            }
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
            if (e.PropertyName == nameof(button.IsToggled))
            {
                IsToggle = button.IsToggled;
            }
        }
        Drawable CreateBackgroundForButton()
        {
            return isToggle ? CreateBackgroundToggle() : CreateBackgroundUnToggle();
        }
        Drawable CreateBackgroundToggle()
        {
            List<Drawable> drawables = new List<Drawable>();
            List<Drawable> drawablesDisabled = new List<Drawable>();
            drawables.Add(BackgroundExtension.CreateBackgroundGradient(button.ToggleStartColor.ToAndroid(),
                button.ToggleEndColor.ToAndroid(),
                button.ToggleCenterColor.ToAndroid(),
                button.CornerRadius,
                button.Angle.ToAndroid()));
            drawablesDisabled.Add(BackgroundExtension.CreateBackgroundGradient(button.ToggleStartColor.ToAndroid(),
                button.ToggleEndColor.ToAndroid(),
                button.ToggleCenterColor.ToAndroid(),
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
        Drawable CreateBackgroundUnToggle()
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