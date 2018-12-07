using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Genesis.Core.Utilities
{
    public class ServiceCaller
    {
        public async Task<string> Invoke(string url, string parameter, HttpMethod actionMethod)
        {
            using (HttpClient client = new HttpClient())
            using (HttpRequestMessage request = new HttpRequestMessage())
            {
                request.RequestUri = new Uri(url);
                request.Method = actionMethod;
                request.Headers.Add("api-key", Resources.Configs.ApiKey);

                if (request.Method != HttpMethod.Get)
                    request.Content = new StringContent(parameter, Encoding.UTF8, "application/json");

                

                var task = await client.SendAsync(request);

                var result = task.Content.ReadAsStringAsync();



                return result.Result;
            }

        }
    }
}
