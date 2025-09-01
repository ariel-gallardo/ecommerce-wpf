using Ecommerce.Application;
using Ecommerce.ViewModels.Extensions;
using Ecommerce.ViewModelServices;
using Ecommerce.Views;
using Ecommerce.Views.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Ecommerce.Presentation
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private static ServiceProvider _serviceProvider;
        public static ServiceProvider Services => _serviceProvider;

        public App()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.ConfigureServices();
            serviceCollection.ConfigureViews();
            serviceCollection.ConfigureViewModels();
            serviceCollection.ConfigureViewModelServices();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var vmServices = _serviceProvider.GetRequiredService<IViewModelServices>();
            vmServices?.ShowMainView();
        }
    }

}
