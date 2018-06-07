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
using Android.Support.V4.View;
using Android.Views;
using Android.Widget;
using Skor.Controls.Abstractions;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(global::Skor.Controls.GradientTextButton), typeof(global::Skor.Controls.Droid.GradientTextButtonRenderer))]
namespace Skor.Controls.Droid
{
    public class GradientTextButtonRenderer: Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<GradientTextButton, FrameLayout>
    {
        public GradientTextButtonRenderer(Context context):base(context)
        {

        }
        private Xamarin.Forms.Color backgroundColor;
        private const int DEFAULT_HEIGHT_BUTTON = 56;
        private Android.Support.V7.Widget.AppCompatButton nButton;
        private global::Skor.Controls.GradientTextButton button;
        private FrameLayout frame;
        protected override void OnElementChanged(ElementChangedEventArgs<global::Skor.Controls.GradientTextButton> e)
        {
            base.OnElementChanged(e);
            this.button = e.NewElement as global::Skor.Controls.GradientTextButton;
            this.backgroundColor = this.button.BackgroundColor;
            this.button.BackgroundColor = Xamarin.Forms.Color.Transparent;
            this.button.HeightRequest = this.button.HeightRequest >= DEFAULT_HEIGHT_BUTTON ? this.button.HeightRequest : DEFAULT_HEIGHT_BUTTON;
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
            nButton.Text = button.Text;

            nButton.Background = CreateBackgroundButton();
            nButton.AddRipple(button.RippleColor.ToAndroid());
            nButton.Enabled = button.IsEnabled;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName=="Width" || e.PropertyName == "Height")
            {
                nButton.Paint.SetShader(CreateGradient());
                UpdateLayout();
            }
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "IsEnabled")
            {
                if (e.PropertyName == "IsEnabled")
                {
                    nButton.Enabled = button.IsEnabled;
                    nButton.Paint.SetShader(CreateGradient());
                    UpdateLayout();
                }
            }
        }
        private Shader CreateGradient()
        {
            if (button.IsEnabled)
            {
                return BackgroundExtension.CreateLinearGradient(button.StartColor.ToAndroid(),
                button.EndColor.ToAndroid(),
                button.CenterColor.ToAndroid(), (float)button.Width, (float)button.Height);
            }
            return BackgroundExtension.CreateLinearGradient(Android.Graphics.Color.Gray,
                    Android.Graphics.Color.Gray,
                    Android.Graphics.Color.Gray, (float)button.Width, (float)button.Height);
        }
        private Drawable CreateBackgroundButton()
        {
            var layer1 = BackgroundExtension.CreateBackgroundGradient(button.StartColor.ToAndroid(),
                button.EndColor.ToAndroid(),
                button.CenterColor.ToAndroid(), button.CornerRadius, button.Angle.ToAndroid());
            var layer1Disabled = BackgroundExtension.CreateBackgroundGradient(Android.Graphics.Color.Gray,
                    Android.Graphics.Color.Gray,
                    Android.Graphics.Color.Gray, button.CornerRadius, button.Angle.ToAndroid());
            var layer2Temp = BackgroundExtension.CreateBackgroundGradient(backgroundColor.ToAndroid(),
                backgroundColor.ToAndroid(),
                backgroundColor.ToAndroid(), button.CornerRadius, button.Angle.ToAndroid());
            int borderWidth = button.BorderWidth;
            var layer2 = new InsetDrawable(layer2Temp, borderWidth, borderWidth, borderWidth, borderWidth);
            Drawable[] drawables = new Drawable[] { layer1, layer2 };
            Drawable[] drawablesDisabled = new Drawable[] { layer1Disabled, layer2 };
            LayerDrawable layer = new LayerDrawable(drawables);
            LayerDrawable layerDisabled = new LayerDrawable(drawablesDisabled);
            var statesListDrawable = new StateListDrawable();
            statesListDrawable.AddState(new int[] { -Android.Resource.Attribute.StateEnabled }, layerDisabled);
            statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StatePressed }, layer);
            statesListDrawable.AddState(new int[] { Android.Resource.Attribute.StateEnabled }, layer);
            return statesListDrawable;
        }
    }
}