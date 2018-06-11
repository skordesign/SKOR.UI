using Skor.Controls.EventArguments;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class GradientToggleButton : Button
    {
        public event EventHandler Toggle;
        public static readonly BindableProperty UntoggledBackgroundColorProperty = BindableProperty.Create(
        nameof(UntoggledBackgroundColor),
        typeof(Color),
        typeof(GradientToggleButton),
        Color.Gray);
        public Color UntoggledBackgroundColor
        {
            get { return (Color)GetValue(UntoggledBackgroundColorProperty); }
            set { SetValue(UntoggledBackgroundColorProperty, value); }
        }
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
         nameof(StartColor),
         typeof(Color),
         typeof(GradientToggleButton),
         Color.Default);
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }
        public static readonly BindableProperty RippleColorProperty = BindableProperty.Create(
              nameof(RippleColor),
              typeof(Color),
              typeof(GradientToggleButton),
              Color.White);
        public Color RippleColor
        {
            get { return (Color)GetValue(RippleColorProperty); }
            set { SetValue(RippleColorProperty, value); }
        }
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
        nameof(EndColor),
        typeof(Color),
        typeof(GradientToggleButton),
        Color.Default);
        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }
        public static readonly BindableProperty CenterColorProperty = BindableProperty.Create(
        nameof(CenterColor),
        typeof(Color),
        typeof(GradientToggleButton),
        Color.Transparent);
        public Color CenterColor
        {
            get { return (Color)GetValue(CenterColorProperty); }
            set { SetValue(CenterColorProperty, value); }
        }

        public static readonly BindableProperty AngleProperty = BindableProperty.Create(
        nameof(Angle),
        typeof(AngleGradient),
        typeof(GradientToggleButton),
        AngleGradient.LeftRight);
        public AngleGradient Angle
        {
            get { return (AngleGradient)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public static readonly BindableProperty IsToggledProperty = BindableProperty.Create(
       nameof(IsToggled),
       typeof(bool),
       typeof(GradientToggleButton),
       false);
        public bool IsToggled
        {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }
        public void SendToggle()
        {
            IsToggled = !IsToggled;
            Toggle?.Invoke(this, new ToggleEventArgs(IsToggled, !IsToggled));
        }
    }
}
