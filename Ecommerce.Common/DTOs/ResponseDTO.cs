using System.Net;

namespace Ecommerce.Common.DTOs
{
    public class ResponseDTO
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class ResponseDTO<T> : ResponseDTO
    {
        public T Data { get; set; }
    }
}
