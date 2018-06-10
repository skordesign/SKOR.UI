using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(global::Skor.Controls.GradientToggleButton), typeof(global::Skor.Controls.Droid.GradientToggleButtonRenderer))]
namespace Skor.Controls.Droid
{
    public class GradientToggleButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ViewRenderer<global::Skor.Controls.GradientToggleButton, FrameLayout>
    {
        public GradientToggleButtonRenderer(Context context):base(context)
        {

        }
    }
}