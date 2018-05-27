using Android.Content;
using Android.Widget;
using Skor.Controls.Abstractions;
using Skor.Controls.Droid.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(global::Skor.Controls.GradientButton), typeof(global::Skor.Controls.Droid.GradientButtonRenderer))]
namespace Skor.Controls.Droid
{
    public class GradientButtonRenderer: ViewRenderer<global::Skor.Controls.GradientButton, FrameLayout>
    {
        private const int DEFAULT_HEIGHT_BUTTON = 72;
        private ImageView nShadow;
        private Android.Widget.Button nButton;
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
            nButton = new Android.Widget.Button(Context);
            nButton.Text = button.Text;
            nButton.SetTextColor(button.TextColor.ToAndroid());
            var nBtnLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nBtnLayout.SetMargins(16, 16, 16, 16);
            nButton.LayoutParameters = nBtnLayout;
            nShadow = new ImageView(Context);
            var nShadowLayout = new FrameLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);
            nShadowLayout.SetMargins(4, 16, 8, 8);
            nShadow.LayoutParameters = nShadowLayout;
            nButton.SetBackgroundGradientForButton(button);
            if (button.Image!=null && !string.IsNullOrEmpty(button.Image.File))
            {
                nButton.SetBitmapToButton(button);
            }
            nButton.AddRipple(Android.Graphics.Color.Gray);
            nButton.SetAllParentsClip(false);
            //nButton.StateListAnimator = null;
            nShadow.Background = ShadowExtension.AddShadowToButton(button);
            nShadow.Elevation = 48;
            nShadow.TranslationZ = 48;
            nButton.Click += (s, ev) =>
            {
                ((IGradientButtonController)button).SendClicked();
            };
            nButton.LongClick += (s, ev) =>
            {
                ((IGradientButtonController)button).SendLongClick();
            };
            frame.AddView(nShadow);
            frame.AddView(nButton);
            SetNativeControl(this.frame);
        }
    }
}