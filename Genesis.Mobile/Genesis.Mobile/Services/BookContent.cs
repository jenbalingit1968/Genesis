using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api = Genesis.Core.Api;
using Model = Genesis.Core.Model;
namespace Genesis.Mobile.Services
{
    public class BookContent : Interface.Services.IBookContent<Model::BookContentModel>
    {
        Api.BookContent apiService;
        public BookContent()
        {
            apiService = new Api.BookContent();
        }

        List<Model::BookContentModel> items;
       
        public async Task<Model::BookContentModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(x => x.id == id));
        }

        public async Task<IEnumerable<Model::BookContentModel>> GetItemsAsync(string bibleId, bool forceRefresh = false)
        {
            var result = await apiService.GetAllBookContent(bibleId);
            items = JsonConvert.DeserializeObject<List<Model.BookContentModel>>(result);
            return items;

        }

       


    }

}
