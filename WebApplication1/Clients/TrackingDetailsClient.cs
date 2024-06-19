using WebApplication1.Models.TrackingDetailsModel;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace WebApplication1.Clients
{
    public class TrackingDetailsClient
    {
        private static string _apikey = Constants.apikey;

        public async Task <TrackingDetailsModel> GetTrackingDetailsAsync(string ParcelCode)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.17track.net/track/v2.2/gettrackinfo"))
                {
                    request.Headers.TryAddWithoutValidation("17token", _apikey);

                    request.Content = new StringContent("[\n            {\n              \"number\": \"" + ParcelCode + "\"\n            }\n          ]");
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<TrackingDetailsModel>(body);
                
                    return result;

                }
            } 
        }
    }
}
