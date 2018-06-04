using Android.Content;
using Android.Support.V4.View;
using Android.Widget;
using Skor.Controls.Abstractions;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(global::Skor.Controls.GradientButton), typeof(global::Skor.Controls.Droid.GradientButtonRenderer))]
namespace Skor.Controls.Droid
{
    public class GradientButtonRenderer: Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<global::Skor.Controls.GradientButton, FrameLayout>
    {
        private const int DEFAULT_HEIGHT_BUTTON = 72;
        private Android.Support.V7.Widget.AppCompatImageView nShadow;
        private Android.Support.V7.Widget.AppCompatButton nButton;
        private global::Skor.Controls.GradientButton button;
        private FrameLayout frame;
        public GradientButtonRenderer(Context context):base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<global::Skor.Controls.GradientButton> e)
        {
            base.OnElementChanged(e);
            this.button = e.NewElement as global::Skor.Controls.GradientButton;
            this.button.HeightRequest = this.button.HeightRequest != -1 ? this.button.HeightRequest : DEFAULT_HEIGHT_BUTTON;
            frame = new FrameLayout(Context);
            frame.LayoutParameters = new FrameLayout.LayoutParams((int)button.WidthRequest, (int)button.HeightRequest);
            nButton = new Android.Support.V7.Widget.AppCompatButton(Context);
            nButton.Text = button.Text;
            nButton.SetTextColor(button.TextColor.ToAndroid());
            var nBtnLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nBtnLayout.SetMargins(24, 0, 24, 24);
            nButton.LayoutParameters = nBtnLayout;
            nShadow = new Android.Support.V7.Widget.AppCompatImageView(Context);
            var nShadowLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nShadowLayout.SetMargins(12, 16, 12, 2);
            nShadow.LayoutParameters = nShadowLayout;
            nButton.SetBackgroundGradientForButton(button);
            if (button.Image!=null && !string.IsNullOrEmpty(button.Image.File))
            {
                nButton.SetBitmapToButton(button);
            }
            nButton.AddRipple(Android.Graphics.Color.Gray);
            nButton.SetAllParentsClip(false);
            nButton.StateListAnimator = new Android.Animation.StateListAnimator();
            nShadow.Background = ShadowExtension.AddShadowToButton(button);
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
    }
}