using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class MasterDetailCell : ViewCell
    {
        public MasterDetailCell()
        {
            this.PropertyChanged += this.MasterDetailCell_PropertyChanged;
        }

        private void MasterDetailCell_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Height))
            {
                if (Master != null)
                    Master.HeightRequest = Height;
                if (Detail != null)
                    Detail.Margin = new Thickness(0, Height - 8, 0, 0);
            }
        }

        public bool TapMasterToShowDetail
        {
            get; set;
        }
        public static readonly BindableProperty DetailHeightProperty =
          BindableProperty.Create(nameof(DetailHeight), typeof(double), typeof(MasterDetailCell), 80d,
              propertyChanged: OnIsDetailShownChanged);

        public double DetailHeight
        {
            get { return (double)GetValue(DetailHeightProperty); }
            set { SetValue(DetailHeightProperty, value); }
        }
        public static readonly BindableProperty IsDetailShownProperty =
           BindableProperty.Create(nameof(IsDetailShown), typeof(bool), typeof(MasterDetailCell), false,
               propertyChanged: OnIsDetailShownChanged);

        public bool IsDetailShown
        {
            get { return (bool)GetValue(IsDetailShownProperty); }
            set { SetValue(IsDetailShownProperty, value); }
        }
        public static readonly BindableProperty DetailProperty =
           BindableProperty.Create(nameof(Detail), typeof(View), typeof(MasterDetailCell), default(View),
               propertyChanged: OnDetailChanged);
        public View Detail
        {
            get { return (View)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public static readonly BindableProperty MasterProperty =
           BindableProperty.Create(nameof(Master), typeof(View), typeof(MasterDetailCell), default(View),
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
                (bindable as MasterDetailCell).RenderMaster();
            }
        }

        private static void OnDetailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as MasterDetailCell).RenderDetail();
            }
        }
        private void RenderMaster()
        {
            if (Master == null)
                return;
            if (this.View == null)
                this.View = CreateContent();
            var masterTap = new TapGestureRecognizer();
            masterTap.Tapped += (s, e) => ShowDetail();
            Master.GestureRecognizers.Add(masterTap);
            Master.VerticalOptions = LayoutOptions.Start;
            AddToContent();
        }
        private void ShowDetail()
        {
            if (TapMasterToShowDetail)
                IsDetailShown = !IsDetailShown;
        }

        private void RenderDetail()
        {
            if (Detail == null)
                return;
            if (this.View == null)
                this.View = CreateContent();
            Detail.VerticalOptions = LayoutOptions.Start;
            AddToContent();
        }
        private void ChangedDetailVisibility()
        {
            if (Detail != null)
            {
                if (IsDetailShown)
                {
                    Detail.Animate("HeightChange", _ => {
                        Detail.HeightRequest = _;
                        this.ForceUpdateSize();
                    }, 0d, DetailHeight);
                }
                else
                {
                    Detail.Animate("HeightChangeBack", _ => {
                        Detail.HeightRequest = _;
                        this.ForceUpdateSize();
                    }, DetailHeight, 0d);
                }
            }
        }
        private static void OnIsDetailShownChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as MasterDetailCell).ChangedDetailVisibility();
        }
        private View CreateContent()
        {
            return new Grid();
        }
        private void AddToContent()
        {
            if (Master != null && Detail != null)
            {
                (this.View as Grid).Children.Add(Detail);
                (this.View as Grid).Children.Add(Master);
            }
        }
    }
}
