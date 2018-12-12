using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Model = Genesis.Core.Model;

namespace Genesis.Mobile.ViewModels
{
    public class BookChapterViewModel : BaseViewModel
    {
        public ObservableCollection<Model::ChapterModel> BookChapterItem { get; set; }



        public BookChapterViewModel(Model::BookContentModel books)
        {

            BookChapterItem = new ObservableCollection<Model.ChapterModel>();
            Title = books.name;
            var s = books.nameLong;
            LoadChapters(books.chapters);
        }


        public async void LoadChapters(IEnumerable<Model::ChapterModel> items)
        {
            if (Device.RuntimePlatform == Device.Android)
                await Task.Delay(500);
            if (items != null)

                foreach (var item in items)
                {
                    BookChapterItem.Add(item);
                }
        }

    }
}
