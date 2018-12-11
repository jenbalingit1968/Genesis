using Genesis.Mobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Genesis.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Books : ContentPage
	{
        BooksViewModel viewModel;
        public Books ()
		{
			InitializeComponent ();
            BindingContext = viewModel = new BooksViewModel();
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.MenuPage());
        }
    }
}