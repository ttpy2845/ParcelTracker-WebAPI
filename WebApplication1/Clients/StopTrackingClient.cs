using Newtonsoft.Json;
using WebApplication1.Models.StopTrackingModel;
using System.Net.Http.Headers;

namespace WebApplication1.Clients
{
    public class StopTrackingClient
    {
        private static string _apikey = Constants.apikey;

        public async Task <StopTrackingModel> StopTracking (string ParcelCode)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.17track.net/track/v2.2/stoptrack"))
                {
                    request.Headers.TryAddWithoutValidation("17token", _apikey);

                    request.Content = new StringContent("[\n        {\n          \"number\": \"" + ParcelCode + "\",\n          \"carrier\":\n        }\n    ]");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<StopTrackingModel>(body);

                    return result;

                }
            }
        }
    }
}