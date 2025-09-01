using Ecommerce.IViews;
using Microsoft.Extensions.DependencyInjection;


namespace Ecommerce.Views.Extensions
{
    public static class ConfigureViewsExtension
    {
        public static void ConfigureViews(this IServiceCollection services)
        {
            services.AddSingleton<IMainView,MainView>();
            services.AddSingleton<IHomeView,HomeView>();
            services.AddSingleton<ILoginView,LoginView>();
        }
    }
}
