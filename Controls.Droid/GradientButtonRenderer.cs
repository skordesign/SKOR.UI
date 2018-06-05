using System.ComponentModel;
using Android.Animation;
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
        private const int DEFAULT_HEIGHT_BUTTON = 96;
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
            nBtnLayout.SetMargins(24, 0, 24, 36);
            nButton.LayoutParameters = nBtnLayout;
            nButton.SetBackgroundGradientForButton(button);
            if (button.Image!=null && !string.IsNullOrEmpty(button.Image.File))
            {
                nButton.SetBitmapToButton(button);
            }
            nButton.AddRipple(Android.Graphics.Color.White);
            nButton.SetAllParentsClip(false);
            InitStateButton();
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
        private void InitStateButton()
        {
            nButton.Enabled = button.IsEnabled;
            if(!nButton.Enabled)
            {
                nButton.Background.SetAlpha(40);
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
                    if (nButton.Enabled)
                    {
                        nButton.SetBackgroundGradientForButton(button);
                        if (button.Image != null && !string.IsNullOrEmpty(button.Image.File))
                        {
                            nButton.SetBitmapToButton(button);
                        }
                    }
                    else
                    {
                        nButton.Background.SetAlpha(40);
                    }
                }
            }
        }
    }
}