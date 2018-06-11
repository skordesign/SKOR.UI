using Skor.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Controls.Test
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            BindingContext = this;
		}

        private void GradientTextButton_Clicked(object sender, EventArgs e)
        {
            //(sender as GradientTextButton).IsEnabled = false;
           
        }
        ObservableCollection<object> items = new ObservableCollection<object>
        {
            new {Index="One"},
            new {Index = "Two"},
            new {Index="Three"}
        };
        public ObservableCollection<object> Items
        {
            get => items;
        }

        private void Add(object sender, EventArgs e)
        {
            Items.Add(new { Index = Guid.NewGuid().ToString() });
        }

        private void Remove(object sender, EventArgs e)
        {
            Items.RemoveAt(Items.Count - 1);
        }

        private void Toggle(object sender, EventArgs e)
        {
        }
    }

}
