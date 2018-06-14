using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class ClassicEntry:Entry
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
      nameof(CornerRadius),
      typeof(double),
      typeof(ClassicEntry),
      0d);
        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
