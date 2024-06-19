using Newtonsoft.Json;
using ParcelTrackerWebAPI.Models.ParcelDeleteModel;
using System.Net.Http.Headers;
using WebApplication1;

namespace ParcelTrackerWebAPI.Clients
{
    public class ParcelDeleteClient
    {
        private static string _apikey = Constants.apikey;

        public async Task <ParcelDeleteModel> ParcelDelete (string ParcelCode)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.17track.net/track/v2.2/deletetrack"))
                {
                    request.Headers.TryAddWithoutValidation("17token", _apikey);

                    request.Content = new StringContent("[\n      {\n          \"number\": \"" + ParcelCode + "\",\n          \"carrier\": \n      }\n    ]");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject <ParcelDeleteModel> (body);

                    return result;

                }
            }
        }
    }
}
