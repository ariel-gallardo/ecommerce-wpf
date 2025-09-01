using Ecommerce.IViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.ViewModels.Extensions
{
    public static class ConfigureViewModelExtension
    {
        public static void ConfigureViewModels(this IServiceCollection services)
        {
            services.AddSingleton<IMainViewModel, MainViewModel>();
            services.AddSingleton<IHomeViewModel, HomeViewModel>();
            services.AddSingleton<ILoginViewModel, LoginViewModel>();
        }
    }
}
