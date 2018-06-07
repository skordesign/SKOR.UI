using Skor.Controls.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class GradientTextButton : GradientView, IGradientButtonController
    {
        public event EventHandler Clicked;
        public event EventHandler Pressed;
        public event EventHandler Released;
        public event EventHandler LongClicked;
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
          nameof(BorderWidth),
          typeof(float),
          typeof(GradientTextButton),
          24.0f);
        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
           nameof(CornerRadius),
           typeof(float),
           typeof(GradientTextButton),
           24.0f);
        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(GradientTextButton),
            default(string));
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(Command),
            typeof(GradientTextButton),
            default(Command));
        public Command Command
        {
            get { return (Command)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }
        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(
            nameof(CommandParameter),
            typeof(object),
            typeof(GradientTextButton),
            default(object));
        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
        public static readonly BindableProperty LongClickCommandProperty = BindableProperty.Create(
            nameof(LongClickCommand),
            typeof(Command),
            typeof(GradientTextButton),
            default(Command));
        public Command LongClickCommand
        {
            get { return (Command)GetValue(LongClickCommandProperty); }
            set { SetValue(LongClickCommandProperty, value); }
        }
        public static readonly BindableProperty LongClickCommandParameterProperty = BindableProperty.Create(
            nameof(LongClickCommandParameter),
            typeof(object),
            typeof(GradientTextButton),
            default(object));
        public object LongClickCommandParameter
        {
            get { return GetValue(LongClickCommandParameterProperty); }
            set { SetValue(LongClickCommandParameterProperty, value); }
        }
        public void SendClicked()
        {
            Clicked?.Invoke(this, new EventArgs());
            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(CommandParameter);
            }
        }

        public void SendPressed()
        {
            Pressed?.Invoke(this, new EventArgs());
        }

        public void SendReleased()
        {
            Released?.Invoke(this, new EventArgs());
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
