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

        public async Task<Response> GetAsync<Response>(string url, Dictionary<string, string>? headers = null)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, url);
            AddHeaders(request, headers);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> PostAsync<Request, Response>(string url, Request data, Dictionary<string, string>? headers = null)
        {
            var content = CreateJsonContent(data);
            using var request = new HttpRequestMessage(HttpMethod.Post, url) { Content = content };
            AddHeaders(request, headers);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> PutAsync<Request, Response>(string url, Request data, Dictionary<string, string>? headers = null)
        {
            var content = CreateJsonContent(data);
            using var request = new HttpRequestMessage(HttpMethod.Put, url) { Content = content };
            AddHeaders(request, headers);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> PatchAsync<Request, Response>(string url, Request data, Dictionary<string, string>? headers = null)
        {
            var content = CreateJsonContent(data);
            using var request = new HttpRequestMessage(HttpMethod.Patch, url) { Content = content };
            AddHeaders(request, headers);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        public async Task<Response> DeleteAsync<Response>(string url, Dictionary<string, string>? headers = null)
        {
            using var request = new HttpRequestMessage(HttpMethod.Delete, url);
            AddHeaders(request, headers);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return Deserialize<Response>(json);
        }

        // Helpers
        private static void AddHeaders(HttpRequestMessage request, Dictionary<string, string>? headers)
        {
            if (headers == null) return;
            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }

        private static StringContent CreateJsonContent<T>(T data) =>
            new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

        private static T Deserialize<T>(string json) =>
            JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }
}
