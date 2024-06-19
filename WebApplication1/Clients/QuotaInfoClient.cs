using Newtonsoft.Json;
using WebApplication1.Models.QuotaInfoModel;
using System.Net.Http.Headers;

namespace WebApplication1.Clients
{
    public class QuotaInfoClient
    {
        private static string _apikey = Constants.apikey;

        public async Task <QuotaInfoModel> QuotaInfoAsync()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://api.17track.net/track/v2.2/getquota"))
                {
                    request.Headers.TryAddWithoutValidation("17token", _apikey);

                    var response = await httpClient.SendAsync(request);
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject <QuotaInfoModel> (body);

                    return result;
                }
            }
        }
    }
}