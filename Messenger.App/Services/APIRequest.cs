using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;
using System.Net.Http;
using System.Text;


namespace Messenger.App.Services
{
    public class APIRequest
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public APIRequest(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        public async Task<T?> GetDataAsync<T>(string endpoint)
        {
            string? url = _configuration["APIURL"] + endpoint;

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var responce = await _httpClient.SendAsync(request);

            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string responceBody = await responce.Content.ReadAsStringAsync();
                T? data = JsonConvert.DeserializeObject<T>(responceBody);

                return data;
            }

            return default;
        }

        public async Task PostDataAsync(string endpoint, object data)
        {
            string? url = _configuration["APIURL"] + endpoint;

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
            };

            await _httpClient.SendAsync(request);
        }

        public async Task<T?> PostDataAsync<T>(string endpoint, object data)
        {
            string? url = _configuration["APIURL"] + endpoint;

            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
            };

            var responce = await _httpClient.SendAsync(request);

            if (responce.StatusCode == HttpStatusCode.OK)
            {
                string responceBody = await responce.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responceBody);
            }

            return default;
        }
    }
}
