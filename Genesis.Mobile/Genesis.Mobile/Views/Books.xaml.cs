using Genesis.Mobile.Models;
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

        MainPage RootPage { get => Application.Current.MainPage as MainPage; }
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

         void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Genesis.Core.Model.BooksModel;
            if (item == null)
                return;

            //await Navigation.PushAsync(new Views.BookContent(item));

             RootPage.Detail =  new NavigationPage(new Views.BookContent(item));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
}