namespace Ecommerce.Application.IServices
{
    public interface IHttpServices
    {
        Task<Response> GetAsync<Response>(string url, Dictionary<string, string>? headers = null);
        Task<Response> PostAsync<Request, Response>(string url, Request data, Dictionary<string, string>? headers = null);
        Task<Response> PutAsync<Request, Response>(string url, Request data, Dictionary<string, string>? headers = null);
        Task<Response> PatchAsync<Request, Response>(string url, Request data, Dictionary<string, string>? headers = null);
        Task<Response> DeleteAsync<Response>(string url, Dictionary<string, string>? headers = null);
    }
}
