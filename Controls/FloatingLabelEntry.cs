using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static Xamarin.Forms.Button.ButtonContentLayout;

namespace Skor.Controls
{
    public class FloatingLabelEntry : Entry
    {
        public static readonly BindableProperty ErrorMessageProperty = BindableProperty.Create(
       nameof(ErrorMessage),
       typeof(string),
       typeof(FloatingLabelEntry),
       string.Empty);
        public string ErrorMessage
        {
            get { return (string)GetValue(ErrorMessageProperty); }
            set { SetValue(ErrorMessageProperty, value); }
        }
        public static readonly BindableProperty ErrorEnabledProperty = BindableProperty.Create(
       nameof(ErrorEnabled),
       typeof(bool),
       typeof(FloatingLabelEntry),
       false);
        public bool ErrorEnabled
        {
            get { return (bool)GetValue(ErrorEnabledProperty); }
            set { SetValue(ErrorEnabledProperty, value); }
        }
        public static readonly BindableProperty LabelColorProperty = BindableProperty.Create(
        nameof(LabelColor),
        typeof(Color),
        typeof(FloatingLabelEntry),
        Color.Black);
        public Color LabelColor
        {
            get { return (Color)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
       nameof(CornerRadius),
       typeof(double),
       typeof(FloatingLabelEntry),
       4d);
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly BindableProperty FocusColorProperty = BindableProperty.Create(
        nameof(FocusColor),
        typeof(Color),
        typeof(FloatingLabelEntry),
        Color.White);
        public Color FocusColor
        {
            get { return (Color)GetValue(FocusColorProperty); }
            set { SetValue(FocusColorProperty, value); }
        }
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
      nameof(BackgroundColor),
      typeof(Color),
      typeof(FloatingLabelEntry),
      Color.LightGray);
        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }
        public static readonly BindableProperty DisabledColorProperty = BindableProperty.Create(
       nameof(DisabledColor),
       typeof(Color),
       typeof(FloatingLabelEntry),
       Color.WhiteSmoke);
        public Color DisabledColor
        {
            get { return (Color)GetValue(DisabledColorProperty); }
            set { SetValue(DisabledColorProperty, value); }
        }
        public static readonly BindableProperty IconProperty = BindableProperty.Create(
        nameof(Icon),
        typeof(FileImageSource),
        typeof(FloatingLabelEntry),
        default(FileImageSource));
        public FileImageSource Icon
        {
            get { return (FileImageSource)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }
        public static readonly BindableProperty IconPositionProperty = BindableProperty.Create(
        nameof(IconPosition),
        typeof(ImagePosition),
        typeof(FloatingLabelEntry),
        ImagePosition.Left);
        public ImagePosition IconPosition
        {
            get { return (ImagePosition)GetValue(IconPositionProperty); }
            set { SetValue(IconPositionProperty, value); }
        }
    }
}
