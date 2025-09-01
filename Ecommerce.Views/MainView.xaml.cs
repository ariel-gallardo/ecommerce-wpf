using Ecommerce.IViewModels;
using Ecommerce.IViews;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Ecommerce.Views
{
    /// <summary>
    /// Lógica de interacción para MainView.xaml
    /// </summary>
    public partial class MainView : Window, IMainView
    {

        public MainView()
        {
            InitializeComponent();
            //_viewModelServices = viewModelServices;
            //DataContext = main;
            //Loaded += MainWindow_Loaded;
        }

        //await _viewModelServices.LoadAsync();

    }
}
