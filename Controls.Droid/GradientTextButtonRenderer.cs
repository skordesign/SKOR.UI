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
        private const int DEFAULT_HEIGHT_BUTTON = 72;
        private Android.Support.V7.Widget.AppCompatImageView nShadow;
        private Android.Support.V7.Widget.AppCompatButton nButton;
        private global::Skor.Controls.GradientTextButton button;
        private FrameLayout frame;
        protected override void OnElementChanged(ElementChangedEventArgs<global::Skor.Controls.GradientTextButton> e)
        {
            base.OnElementChanged(e);
            this.button = e.NewElement as global::Skor.Controls.GradientTextButton;
            this.backgroundColor = this.button.BackgroundColor;
            this.button.BackgroundColor = Xamarin.Forms.Color.Transparent;
            this.button.HeightRequest = this.button.HeightRequest != -1 ? this.button.HeightRequest : DEFAULT_HEIGHT_BUTTON;
            frame = new FrameLayout(Context);
            frame.LayoutParameters = new FrameLayout.LayoutParams((int)button.WidthRequest, (int)button.HeightRequest);
            nButton = new Android.Support.V7.Widget.AppCompatButton(Context);
            nButton.Text = button.Text;
            var nBtnLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nBtnLayout.SetMargins(24, 0, 24, 24);
            nButton.LayoutParameters = nBtnLayout;
            nShadow = new Android.Support.V7.Widget.AppCompatImageView(Context);
            var nShadowLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nShadowLayout.SetMargins(12, 16, 12, 2);
            nShadow.LayoutParameters = nShadowLayout;
            nButton.Background = CreateBackgroundButton();
            if (!button.IsEnabled)
            {
                nButton.Background.SetAlpha(40);
            }
            nButton.AddRipple(Android.Graphics.Color.Gray);
            nButton.SetAllParentsClip(false);
            //nButton.StateListAnimator = null;
            nShadow.SetBackgroundColor( Android.Graphics.Color.Black);
            nButton.Click += (s, ev) =>
            {
                ((IGradientButtonController)button).SendClicked();
            };
            nButton.LongClick += (s, ev) =>
            {
                ((IGradientButtonController)button).SendLongClick();
            };
            //frame.AddView(nShadow);
            frame.AddView(nButton);
            SetNativeControl(this.frame);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName=="Width" || e.PropertyName == "Height")
            {
                nButton.Paint.SetShader(CreateGradient());
               // UpdateLayout();
            }
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == "IsEnabled")
            {
                if (e.PropertyName == "IsEnabled")
                {
                    nButton.Enabled = button.IsEnabled;
                    if (nButton.Enabled)
                    {
                        nButton.Background.SetAlpha(255);
                    }
                    else
                    {
                        nButton.Background.SetAlpha(40);
                    }
                }
            }
        }
        private Shader CreateGradient()
        {
            return BackgroundExtension.CreateLinearGradient(button.StartColor.ToAndroid(),
                button.EndColor.ToAndroid(),
                button.CenterColor.ToAndroid(),(float)button.Width, (float)button.Height);
        }
        private Drawable CreateBackgroundButton()
        {
            var layer1 = BackgroundExtension.CreateBackgroundGradient(button.StartColor.ToAndroid(),
                button.EndColor.ToAndroid(),
                button.CenterColor.ToAndroid(), button.CornerRadius, button.Angle.ToAndroid());
            var layer2Temp = BackgroundExtension.CreateBackgroundGradient(backgroundColor.ToAndroid(),
                backgroundColor.ToAndroid(),
                backgroundColor.ToAndroid(), button.CornerRadius, button.Angle.ToAndroid());
            var layer2 = new InsetDrawable(layer2Temp, 4, 4, 4, 4);
            Drawable[] drawables = new Drawable[] { layer1, layer2 };

            return new LayerDrawable(drawables);
        }
    }
}