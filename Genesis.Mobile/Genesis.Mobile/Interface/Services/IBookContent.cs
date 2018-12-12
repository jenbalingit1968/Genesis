using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Model = Genesis.Core.Model;

namespace Genesis.Mobile.Interface.Services
{
    public interface IBookContent<T>
    {
        Task<IEnumerable<Model::BookContentModel>> GetItemsAsync(string bibleId, bool forceRefresh = false);
        Task<Model::BookContentModel> GetItemAsync(string id);
    }
}
