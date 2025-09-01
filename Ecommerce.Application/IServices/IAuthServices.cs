using Ecommerce.Common.DTOs;
using System.Net;

namespace Ecommerce.Application
{
    public interface IAuthServices
    {
        bool IsTokenExpired(string token);
        bool IsTokenExpired(Cookie cookie);
        Task<ResponseDTO> Authenticate(LoginDTO loginDTO);
    }
}
