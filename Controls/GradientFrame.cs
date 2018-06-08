using Xamarin.Forms;

namespace Skor.Controls
{
    public class GradientFrame: Frame
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
         nameof(StartColor),
         typeof(Color),
         typeof(GradientFrame),
         Color.Default);
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
        nameof(EndColor),
        typeof(Color),
        typeof(GradientFrame),
        Color.Default);
        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }
        public static readonly BindableProperty CenterColorProperty = BindableProperty.Create(
        nameof(CenterColor),
        typeof(Color),
        typeof(GradientFrame),
        Color.Transparent);
        public Color CenterColor
        {
            get { return (Color)GetValue(CenterColorProperty); }
            set { SetValue(CenterColorProperty, value); }
        }

        public static readonly BindableProperty AngleProperty = BindableProperty.Create(
        nameof(Angle),
        typeof(AngleGradient),
        typeof(GradientFrame),
        AngleGradient.LeftRight);
        public AngleGradient Angle
        {
            get { return (AngleGradient)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(FileImageSource),
            typeof(GradientFrame),
            default(FileImageSource));
        public FileImageSource Image
        {
            get { return (FileImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
    }
}
