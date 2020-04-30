using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelMonkey.Models;

namespace TravelMonkey.Services
{
    public class FaceService
    {
        private readonly HttpClient Client = new HttpClient();

         public async Task<FacesResult> AnalyseFaces(Uri url)
        {
            var json = $"{{ \"url\": \"{url.OriginalString}\" }}";

            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await Client.PostAsync(ApiKeys.AzureFunctionFacesEndpoint, content);
            if (!res.IsSuccessStatusCode)
            {
                return new FacesResult { ErrorMessage = res.StatusCode.ToString() };
            }
            var jsonres = await res.Content.ReadAsStringAsync();
           
            return new FacesResult { FacesItems = JsonConvert.DeserializeObject<List<FaceDetection>>(jsonres) } ;
        }
    }
}
