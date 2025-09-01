using Ecommerce.Application.IServices;
using System.Net;
using System.Net.Http;

namespace Ecommerce.Application.Services
{
    public class HttpCookieServices : IHttpCookieServices
    {
        private readonly HttpClientHandler _handler;
        private readonly HttpClient _client;
    
        public HttpCookieServices()
        {
            _handler = new HttpClientHandler
            {
                UseCookies = true,
                CookieContainer = new CookieContainer()
            };
    
            _client = new HttpClient(_handler);
        }
    
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await _client.GetAsync(url);
        }

        public Cookie GetCookie(string url, string name)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            Uri uri = new Uri(url);
            var cookies = _handler.CookieContainer.GetCookies(uri);
            return cookies.FirstOrDefault(x => x.Name == name);
        }

        public List<Cookie> GetCookies(string url)
        {
            Uri uri = new Uri(url);
            var cookies = _handler.CookieContainer.GetCookies(uri);
            return cookies.ToList();
        }
    }
}
