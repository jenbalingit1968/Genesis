using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Model = Genesis.Core.Model;
namespace Genesis.Mobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BookChapter : ContentPage
	{
        ViewModels.BookChapterViewModel viewModel;
		public BookChapter (Model::BookContentModel book)
		{
			InitializeComponent ();
            BindingContext = viewModel = new ViewModels.BookChapterViewModel(book);
        }

    
    }
}