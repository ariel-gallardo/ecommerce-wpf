using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ViewModelServices
{
    public static class ViewModelServicesExtension
    {
        public static void ConfigureViewModelServices(this IServiceCollection services)
        {
            services.AddSingleton<IViewModelServices, ViewModelServices>();
        }
    }
}
