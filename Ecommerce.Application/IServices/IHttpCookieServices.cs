using System.Net;
using System.Net.Http;

namespace Ecommerce.Application.IServices
{
    public interface IHttpCookieServices
    {
        Task<HttpResponseMessage> GetAsync(string url);
        List<Cookie> GetCookies(string url);
        Cookie GetCookie(string url, string name);
    }
}
