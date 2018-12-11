using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Model = Genesis.Core.Model;

namespace Genesis.Mobile.ViewModels
{
    public class BooksViewModel : BaseViewModel
    {
        public ObservableCollection<Model::BooksModel> BooksItem { get; set; }


        public Command LoadItemsCommand { get; set; }

        public BooksViewModel()
        {
            Title = "Books";
            BooksItem = new ObservableCollection<Model::BooksModel>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            GetBooks();
            //MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            //{
            //    var newItem = item as Item;
            //    Items.Add(newItem);
            //    await DataStore.AddItemAsync(newItem);
            //});
        


        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                BooksItem.Clear();
                var items = await BooksStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    BooksItem.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async void GetBooks()
        {
            await ExecuteLoadItemsCommand();
        }
    }
}
