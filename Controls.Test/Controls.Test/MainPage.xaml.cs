using Skor.Controls;
using System;
using System.Collections.Generic;
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
		}

        private void GradientTextButton_Clicked(object sender, EventArgs e)
        {
            //(sender as GradientTextButton).IsEnabled = false;
        }
    }
}
