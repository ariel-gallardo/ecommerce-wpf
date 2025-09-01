using AutoMapper;
using Ecommerce.Application.IServices;
using Ecommerce.Common.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Net.Http;

namespace Ecommerce.Application.Services
{
    public class AuthServices : IAuthServices
    {
        private readonly JwtSecurityTokenHandler _handler;
        private readonly IHttpServices _httpServices;
        private readonly IMapper _mapper;

        public AuthServices(IHttpServices httpServices, IMapper mapper)
        {
            _handler = new JwtSecurityTokenHandler();
            _httpServices = httpServices;
            _mapper = mapper;
        }

        public bool IsTokenExpired(string token)
        {
            if (!string.IsNullOrWhiteSpace(token))
            {
                var jwtToken = _handler.ReadJwtToken(token);
                var expirationTime = jwtToken.ValidTo;
                if (expirationTime >= DateTime.UtcNow)
                    return true;
                return false;
            }
            return true;
        }

        public async Task<ResponseDTO> Authenticate(LoginDTO loginDTO)
        {
            try
            {
               return await _httpServices.PostAsync<LoginDTO, ResponseDTO>("", new LoginDTO { });
            }
            catch(HttpRequestException e)
            {
                return _mapper.Map<ResponseDTO>(e);
            }
        }

        public bool IsTokenExpired(Cookie cookie)
        {
            if (cookie != null && !string.IsNullOrWhiteSpace(cookie.Value))
            {
                var jwtToken = _handler.ReadJwtToken(cookie.Value);
                var expirationTime = jwtToken.ValidTo;
                if (expirationTime >= DateTime.UtcNow)
                    return true;
                return false;
            }
            return true;
        }
    }
}
