using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Model = Genesis.Core.Model;

namespace Genesis.Mobile.ViewModels
{
    public class BookContentViewModel : BaseViewModel
    {
        public ObservableCollection<Model::BookContentModel> BookContentItem { get; set; }


        public Command LoadItemsCommand { get; set; }

        string _bibleId;
        public BookContentViewModel(Model::BooksModel bible)
        {
            _bibleId = bible.Id;
            Title = bible.Name;
            BookContentItem = new ObservableCollection<Model.BookContentModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            GetBookContent();
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                BookContentItem.Clear();
                var items = await BookContentStore.GetItemsAsync(_bibleId ,true);
                foreach (var item in items)
                {
                    BookContentItem.Add(item);
                }
            }
            catch (Exception ex)
            {
               
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void GetBookContent()
        {
            await ExecuteLoadItemsCommand();
        }
    }
}
