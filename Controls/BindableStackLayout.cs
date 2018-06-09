using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Xamarin.Forms;

namespace Skor.Controls
{
    public class BindableStackLayout : StackLayout
    {
        public static readonly BindableProperty ItemsSourceProperty =
             BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(BindableStackLayout), default(IEnumerable), propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BindableStackLayout)bindable;
            if (oldValue is INotifyCollectionChanged oldObservableCollection)
            {
                oldObservableCollection.CollectionChanged -= control.ItemsSourceCollectionChanged;
            }
            if (newValue is INotifyCollectionChanged newObservableCollection)
            {
                newObservableCollection.CollectionChanged += control.ItemsSourceCollectionChanged;
            }
            (bindable as BindableStackLayout)?.RenderView();
        }

        private void ItemsSourceCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var invalidate = false;

            if (e.OldItems != null)
            {
                for (var i = 0; i < e.OldItems.Count; ++i)
                {
                    this.Children.RemoveAt(e.OldStartingIndex+i);
                }
                invalidate = true;
            }

            if (e.NewItems != null)
            {
                for (var i = 0; i < e.NewItems.Count; ++i)
                {
                    var item = e.NewItems[i];
                    var view = this.CreateChildViewFor(item);
                    this.Children.Insert(i + e.NewStartingIndex, view);
                }

                invalidate = true;
            }

            if (invalidate)
            {
                this.UpdateChildrenLayout();
                this.InvalidateLayout();
            }
        }
        private View CreateChildViewFor(object item)
        {
            this.ItemTemplate.SetValue(BindableObject.BindingContextProperty, item);
            return (View)this.ItemTemplate.CreateContent();
        }
        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(BindableStackLayout), default(DataTemplate));

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate)GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }
        private void AddView(object item)
        {
            var view = this.ItemTemplate.CreateContent() as View;
            view.BindingContext = item;
            this.Children.Add(view);
        }
        public void RenderView()
        {
            if (this.ItemTemplate == null || this.ItemsSource == null)
                return;
            foreach (var item in this.ItemsSource)
            {
                AddView(item);
            }
        }
    }
}
