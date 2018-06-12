using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class MasterDetailView : ContentView
    {
        public static readonly BindableProperty IsDetailShownProperty =
           BindableProperty.Create(nameof(IsDetailShown), typeof(bool), typeof(MasterDetailView), false);
        public bool IsDetailShown
        {
            get { return (bool)GetValue(IsDetailShownProperty); }
            set { SetValue(IsDetailShownProperty, value); }
        }
        public static readonly BindableProperty DetailProperty =
           BindableProperty.Create(nameof(Detail), typeof(View), typeof(MasterDetailView), default(View),
               propertyChanged: OnDetailChanged);
        public View Detail
        {
            get { return (View)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public static readonly BindableProperty MasterProperty =
           BindableProperty.Create(nameof(Master), typeof(View), typeof(MasterDetailView), default(View),
               propertyChanged: OnMasterChanged);

        public View Master
        {
            get { return (View)GetValue(MasterProperty); }
            set { SetValue(MasterProperty, value); }
        }
        private static void OnMasterChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as MasterDetailView).RenderMaster();
            }
        }

        private static void OnDetailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as MasterDetailView).RenderDetail();
            }
        }
        private void RenderMaster()
        {
            if (Master == null)
                return;
            if (this.Content == null)
                this.Content = new StackLayout() { Orientation = StackOrientation.Horizontal };
            (this.Content as StackLayout).Children.Add(Master);
        }
        private void RenderDetail()
        {
            if (Detail == null)
                return;
            if (this.Content == null)
                this.Content = new StackLayout() { Orientation = StackOrientation.Horizontal };
            Detail.SetBinding(View.IsVisibleProperty, nameof(IsDetailShown));
            (this.Content as StackLayout).Children.Add(Detail);
        }
    }
}
