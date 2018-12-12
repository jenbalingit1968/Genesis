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
	public partial class BookContent : ContentPage
	{
        ViewModels.BookContentViewModel viewModel;
		public BookContent (Core.Model.BooksModel books)
		{
			InitializeComponent ();
            BindingContext = viewModel = new ViewModels.BookContentViewModel(books);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Genesis.Core.Model.BookContentModel;
            if (item == null)
                return;

            await Navigation.PushAsync(new Views.BookChapter(item));
         
            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }
    }
}