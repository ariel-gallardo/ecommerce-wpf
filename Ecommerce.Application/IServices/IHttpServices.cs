namespace Ecommerce.Application.IServices
{
    public interface IHttpServices
    {
        Task<Response> GetAsync<Response>(string url);
        Task<Response> PostAsync<Request, Response>(string url, Request data);
        Task<Response> PutAsync<Request, Response>(string url, Request data);
        Task<Response> PatchAsync<Request, Response>(string url, Request data);
        Task<Response> DeleteAsync<Response>(string url);
    }
}
