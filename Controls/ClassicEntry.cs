using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class ClassicEntry : Entry
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
        nameof(CornerRadius),
        typeof(double),
        typeof(ClassicEntry),
        4d);
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly BindableProperty FocusColorProperty = BindableProperty.Create(
        nameof(FocusColor),
        typeof(Color),
        typeof(ClassicEntry),
        Color.White);
        public Color FocusColor
        {
            get { return (Color)GetValue(FocusColorProperty); }
            set { SetValue(FocusColorProperty, value); }
        }
        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
      nameof(BackgroundColor),
      typeof(Color),
      typeof(ClassicEntry),
      Color.LightGray);
        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }
        public static readonly BindableProperty DisabledColorProperty = BindableProperty.Create(
       nameof(DisabledColor),
       typeof(Color),
       typeof(ClassicEntry),
       Color.WhiteSmoke);
        public Color DisabledColor
        {
            get { return (Color)GetValue(DisabledColorProperty); }
            set { SetValue(DisabledColorProperty, value); }
        }
    }
}
