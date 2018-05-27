using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class GradientView : View
    {
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
       nameof(StartColor),
       typeof(Color),
       typeof(GradientView),
       Color.Default);
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
        nameof(EndColor),
        typeof(Color),
        typeof(GradientView),
        Color.Default);
        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }
        public static readonly BindableProperty CenterColorProperty = BindableProperty.Create(
        nameof(CenterColor),
        typeof(Color),
        typeof(GradientView),
        Color.Transparent);
        public Color CenterColor
        {
            get { return (Color)GetValue(CenterColorProperty); }
            set { SetValue(CenterColorProperty, value); }
        }

        public static readonly BindableProperty AngleProperty = BindableProperty.Create(
        nameof(Angle),
        typeof(AngleGradient),
        typeof(GradientView),
        AngleGradient.LeftRight);
        public AngleGradient Angle
        {
            get { return (AngleGradient)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            nameof(Image),
            typeof(FileImageSource),
            typeof(GradientView),
            default(FileImageSource));
        public FileImageSource Image
        {
            get { return (FileImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }
       
    }
    public enum AngleGradient
    {
        LeftRight,
        RightLeft,
        BottomTop,
        TopBottom,
        TopRightBottomLeft,
        TopLeftBottomRight,
        BottomRightTopLeft,
        BottomLeftTopRight
    }
}
