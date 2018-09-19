using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class ExpanxibleCell : ViewCell
    {
        public bool TapMasterToShowDetail
        {
            get; set;
        }
        public static readonly BindableProperty DetailHeightProperty =
          BindableProperty.Create(nameof(DetailHeight), typeof(double), typeof(ExpanxibleCell), 80d,
              propertyChanged: OnIsDetailShownChanged);

        public double DetailHeight
        {
            get { return (double)GetValue(DetailHeightProperty); }
            set { SetValue(DetailHeightProperty, value); }
        }
        public static readonly BindableProperty IsDetailShownProperty =
           BindableProperty.Create(nameof(IsDetailShown), typeof(bool), typeof(ExpanxibleCell), false,
               propertyChanged: OnIsDetailShownChanged);

        public bool IsDetailShown
        {
            get { return (bool)GetValue(IsDetailShownProperty); }
            set { SetValue(IsDetailShownProperty, value); }
        }
        public static readonly BindableProperty DetailProperty =
           BindableProperty.Create(nameof(Detail), typeof(View), typeof(ExpanxibleCell), default(View),
               propertyChanged: OnDetailChanged);
        public View Detail
        {
            get { return (View)GetValue(DetailProperty); }
            set { SetValue(DetailProperty, value); }
        }
        public static readonly BindableProperty MasterProperty =
           BindableProperty.Create(nameof(Master), typeof(View), typeof(ExpanxibleCell), default(View),
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
                (bindable as ExpanxibleCell).RenderMaster();
            }
        }

        private static void OnDetailChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                (bindable as ExpanxibleCell).RenderDetail();
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
            Master.PropertyChanged += this.Master_PropertyChanged;
            AddToContent();
        }

        private void Master_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Master.Height))
            {
                if (Detail != null)
                {
                    Detail.Margin = new Thickness(Detail.Margin.Left, Master.Height - 16, Detail.Margin.Right, Detail.Margin.Bottom);
                }
            }
        }

        private void ShowDetail()
        {
            if (TapMasterToShowDetail)
                IsDetailShown = !IsDetailShown;
            OnTapped();
        }

        private void RenderDetail()
        {
            if (Detail == null)
                return;
            if (this.View == null)
                this.View = CreateContent();
            Detail.VerticalOptions = LayoutOptions.Start;
            Detail.Margin = new Thickness(Detail.Margin.Left, Height - 8, Detail.Margin.Right, Detail.Margin.Bottom);
            AddToContent();
            ChangedDetailVisibility();
        }
        private void ChangedDetailVisibility()
        {
            if (Detail != null)
            {
                if (IsDetailShown)
                {
                    Detail.IsVisible = IsDetailShown;
                    //if (Detail.Height > 0 && Detail.TranslationY!=0)
                    //{
                    //    Detail.TranslateTo(0, 0);
                    //}
                    Detail.Animate("HeightChange", _ =>
                    {
                        Detail.HeightRequest = _;
                        this.ForceUpdateSize();
                    }, 0d, DetailHeight);
                }
                else
                {
                    Detail.Animate("HeightChangeBack", _ =>
                    {
                        Detail.HeightRequest = _;
                        this.ForceUpdateSize();
                    }, DetailHeight, 0d);
                    //if (Detail.Height > 0)
                    //{
                    //    Detail.TranslateTo(0, -Detail.Height).ContinueWith(_ => Device.BeginInvokeOnMainThread(() => Detail.IsVisible = IsDetailShown));
                    //}
                    Task.Delay(250).ContinueWith(_ => Device.BeginInvokeOnMainThread(() => Detail.IsVisible = IsDetailShown));
                }
                var height = Detail.Height;
            }
        }
        private static void OnIsDetailShownChanged(BindableObject bindable, object oldValue, object newValue)
        {
            (bindable as ExpanxibleCell).ChangedDetailVisibility();
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
