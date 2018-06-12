using Skor.Controls.EventArguments;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class GradientToggleButton : Button
    {
        public event EventHandler<ToggleEventArgs> Toggle;
        public static readonly BindableProperty HasShadowProperty = BindableProperty.Create(
      nameof(HasShadow),
      typeof(bool),
      typeof(GradientToggleButton),
      true);
        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }
        public static readonly BindableProperty ToggleStartColorProperty = BindableProperty.Create(
        nameof(ToggleStartColor),
        typeof(Color),
        typeof(GradientToggleButton),
        Color.Gray);
        public Color ToggleStartColor
        {
            get { return (Color)GetValue(ToggleStartColorProperty); }
            set { SetValue(ToggleStartColorProperty, value); }
        }
        public static readonly BindableProperty ToggleCenterColorProperty = BindableProperty.Create(
       nameof(ToggleCenterColor),
       typeof(Color),
       typeof(GradientToggleButton),
       Color.Transparent);
        public Color ToggleCenterColor
        {
            get { return (Color)GetValue(ToggleCenterColorProperty); }
            set { SetValue(ToggleCenterColorProperty, value); }
        }
        public static readonly BindableProperty ToggleEndColorProperty = BindableProperty.Create(
       nameof(ToggleEndColor),
       typeof(Color),
       typeof(GradientToggleButton),
       Color.Gray);
        public Color ToggleEndColor
        {
            get { return (Color)GetValue(ToggleEndColorProperty); }
            set { SetValue(ToggleEndColorProperty, value); }
        }
        public static readonly BindableProperty ToggleTextColorProperty = BindableProperty.Create(
        nameof(ToggleTextColor),
        typeof(Color),
        typeof(GradientToggleButton),
        Color.White);
        public Color ToggleTextColor
        {
            get { return (Color)GetValue(ToggleTextColorProperty); }
            set { SetValue(ToggleTextColorProperty, value); }
        }
        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
         nameof(StartColor),
         typeof(Color),
         typeof(GradientToggleButton),
         Color.WhiteSmoke);

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
        Color.WhiteSmoke);
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
