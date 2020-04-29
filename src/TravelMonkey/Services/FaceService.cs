using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TravelMonkey.Services
{
    public class FaceService
    {
        private readonly HttpClient Client = new HttpClient();

         public async Task AnalyseFaces(Uri url)
        {
            var json = $"{{ \"url\": \"{url.OriginalString}\" }}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await Client.PostAsync(ApiKeys.AzureFunctionFacesEndpoint, content);
            var jsonres = await res.Content.ReadAsStringAsync();
        }
    }
}
