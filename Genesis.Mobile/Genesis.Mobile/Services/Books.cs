using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model = Genesis.Core.Model;
using Api = Genesis.Core.Api;
using Newtonsoft.Json;

namespace Genesis.Mobile.Services
{
    public class Books : IDataStore<Model::BooksModel>
    {
        Api.Books apiService;
        public Books()
        {
            apiService = new Api.Books();
            Init();
        }

        List<Model::BooksModel> items;
        public async Task<bool> AddItemAsync(Model::BooksModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Model::BooksModel item)
        {
            var oldItem = items.Where((Model::BooksModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Model::BooksModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Model::BooksModel> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(x => x.Id == id));
        }

        public async Task<IEnumerable<Model::BooksModel>> GetItemsAsync(bool forceRefresh = false)
        {
            var result = await apiService.GetAllBooks();
            items = JsonConvert.DeserializeObject<List<Model.BooksModel>>(result);
            return items;


        }

        private async void Init()
        {
            await GetItemsAsync();
        }
    }
}
