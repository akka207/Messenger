using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;


namespace Messenger.App.Services.Implementations
{
    public class APIRequest : IAPIRequest
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public APIRequest(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _configuration = configuration;
        }

        public async Task<T> GetDataAsync<T>(string endpoint)
        {
            throw new NotImplementedException();
        }

        public async Task PostDataAsync(string endpoint, object data)
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
            }
        }
    }
}
