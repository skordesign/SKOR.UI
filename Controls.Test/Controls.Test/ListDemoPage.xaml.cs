using Skor.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Controls.Test
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ListDemoPage : ContentPage
	{
		public ListDemoPage ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
        ObservableCollection<object> items = new ObservableCollection<object>
        {
            new {Index="One", IsShow=false },
            new {Index = "Two",IsShow=true},
            new {Index="Three",IsShow=false}
        };
        public ObservableCollection<object> Items
        {
            get => items;
        }

        private void MasterDetailView_MasterClicked(object sender, EventArgs e)
        {
            (sender as ExpanxibleCell).IsDetailShown = !(sender as ExpanxibleCell).IsDetailShown;
        }
    }
}