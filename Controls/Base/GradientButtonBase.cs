using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls.Base
{
    public class GradientButtonBase : Button
    {
        public event EventHandler LongClicked;
        public static readonly BindableProperty HasShadowProperty = BindableProperty.Create(
      nameof(HasShadow),
      typeof(bool),
      typeof(GradientButtonBase),
      true);
        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }

        public static readonly BindableProperty StartColorProperty = BindableProperty.Create(
       nameof(StartColor),
       typeof(Color),
       typeof(GradientButtonBase),
       Color.Default);
        public Color StartColor
        {
            get { return (Color)GetValue(StartColorProperty); }
            set { SetValue(StartColorProperty, value); }
        }
        public static readonly BindableProperty RippleColorProperty = BindableProperty.Create(
              nameof(RippleColor),
              typeof(Color),
              typeof(GradientButtonBase),
              Color.White);
        public Color RippleColor
        {
            get { return (Color)GetValue(RippleColorProperty); }
            set { SetValue(RippleColorProperty, value); }
        }
        public static readonly BindableProperty EndColorProperty = BindableProperty.Create(
        nameof(EndColor),
        typeof(Color),
        typeof(GradientButtonBase),
        Color.Default);
        public Color EndColor
        {
            get { return (Color)GetValue(EndColorProperty); }
            set { SetValue(EndColorProperty, value); }
        }
        public static readonly BindableProperty CenterColorProperty = BindableProperty.Create(
        nameof(CenterColor),
        typeof(Color),
        typeof(GradientButtonBase),
        Color.Transparent);
        public Color CenterColor
        {
            get { return (Color)GetValue(CenterColorProperty); }
            set { SetValue(CenterColorProperty, value); }
        }

        public static readonly BindableProperty AngleProperty = BindableProperty.Create(
        nameof(Angle),
        typeof(AngleGradient),
        typeof(GradientButtonBase),
        AngleGradient.LeftRight);
        public AngleGradient Angle
        {
            get { return (AngleGradient)GetValue(AngleProperty); }
            set { SetValue(AngleProperty, value); }
        }
        public static readonly BindableProperty LongClickCommandProperty = BindableProperty.Create(
            nameof(LongClickCommand),
            typeof(Command),
            typeof(GradientButtonBase),
            default(Command));
        public Command LongClickCommand
        {
            get { return (Command)GetValue(LongClickCommandProperty); }
            set { SetValue(LongClickCommandProperty, value); }
        }
        public static readonly BindableProperty LongClickCommandParameterProperty = BindableProperty.Create(
            nameof(LongClickCommandParameter),
            typeof(object),
            typeof(GradientButtonBase),
            default(object));
        public object LongClickCommandParameter
        {
            get { return GetValue(LongClickCommandParameterProperty); }
            set { SetValue(LongClickCommandParameterProperty, value); }
        }
        public void SendLongClick()
        {
            LongClicked?.Invoke(this, new EventArgs());
            if (LongClickCommand != null && LongClickCommand.CanExecute(null))
            {
                LongClickCommand.Execute(LongClickCommandParameter);
            }
        }
    }
}
