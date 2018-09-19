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
            Navigation.PushAsync(new ListDemoPage());
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
        public Command ChangeProperty
        {
            get => new Command(c =>
             {
                 var temp = Start;
                 Start = Center;
                 Center = End;
                 End = temp;
             });
        }
        private string end = "#f64f59";
        public string End
        {
            get { return end; }
            set
            {
                end = value;
                OnPropertyChanged(nameof(End));
            }
        }
        private string start = "#12c2e9";
        public string Start
        {
            get { return start; }
            set
            {
                start = value;
                OnPropertyChanged(nameof(Start));
            }
        }
        private string center = "#c471ed";
        public string Center
        {
            get { return center; }
            set
            {
                center = value;
                OnPropertyChanged(nameof(Center));
            }
        }
    }

}
