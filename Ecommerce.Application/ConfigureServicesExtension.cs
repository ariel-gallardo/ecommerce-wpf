using AutoMapper;
using Ecommerce.Application.IServices;
using Ecommerce.Application.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Application
{
    public static class ConfigureServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            var assembly = typeof(ConfigureServicesExtension).Assembly;
            services.AddAutoMapper(c => c.AddMaps(assembly));
            services.AddHttpClient();
            services.AddTransient<IHttpServices, HttpServices>();
            services.AddScoped<IAuthServices, AuthServices>();
            services.AddSingleton<IHttpCookieServices, HttpCookieServices>();
        }
    }
}
