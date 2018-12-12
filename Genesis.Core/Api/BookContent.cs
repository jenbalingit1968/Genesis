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
    public class BookContent
    {
        private readonly ServiceCaller serviceCaller;
        public BookContent()
        {
            serviceCaller = new ServiceCaller();
        }


        public async Task<string> GetAllBookContent(string bibleId)
        {
            var url = string.Format("{0}/{1}/books?include-chapters=false&include-chapters-and-sections=true", Resources.Configs.BaseUrl, bibleId);
            var invoke = await serviceCaller.Invoke(url, string.Empty, HttpMethod.Get);
            var get = JsonConvert.DeserializeObject<Model.BookContentResult>(invoke);
            return JsonConvert.SerializeObject(get.Data);

        }
    }
}
