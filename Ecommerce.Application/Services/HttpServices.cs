using System.Net.Http;
using System.Text;
using System.Text.Json;
using Ecommerce.Application.IServices;

namespace Ecommerce.Application.Services
{
    public class HttpServices : IHttpServices
    {
        private readonly HttpClient _httpClient;

        public HttpServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Response> GetAsync<Response>(string url)
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> PostAsync<Request, Response>(string url, Request data)
        {
            var content = CreateJsonContent(data);
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> PutAsync<Request, Response>(string url, Request data)
        {
            var content = CreateJsonContent(data);
            var response = await _httpClient.PutAsync(url, content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> PatchAsync<Request, Response>(string url, Request data)
        {
            var content = CreateJsonContent(data);
            var requestMessage = new HttpRequestMessage(HttpMethod.Patch, url) { Content = content };

            var response = await _httpClient.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> DeleteAsync<Response>(string url)
        {
            var response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        // Métodos utilitarios
        private static StringContent CreateJsonContent<T>(T data)
        {
            return new StringContent(
                JsonSerializer.Serialize(data),
                Encoding.UTF8,
                "application/json"
            );
        }

        private static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        }
    }
}
