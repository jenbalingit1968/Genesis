using Genesis.Core.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;



namespace Genesis.Core.Api
{
    public class Books
    {
        private readonly ServiceCaller serviceCaller;
        public Books()
        {
            serviceCaller = new ServiceCaller();
        }

        public async Task<Model.BooksModel> GetBook(string language, string abbreviation, string name, string ids)
        {
            string reqUrl = $"{Resources.Configs.BaseUrl}?language={language}&abbreviation={abbreviation}&name={name}&ids={ids}";
            var invoke = await serviceCaller.Invoke(reqUrl, string.Empty, HttpMethod.Get);
            var get = JsonConvert.DeserializeObject<Model.Result>(invoke);
            return get.Data.FirstOrDefault();
        }

        public async Task<string> GetAllBooks()
        {
            var invoke = await serviceCaller.Invoke(Resources.Configs.BaseUrl, string.Empty, HttpMethod.Get);
            var get = JsonConvert.DeserializeObject<Model.Result>(invoke);
            return JsonConvert.SerializeObject(get.Data);
            
        }


        
    }
}
