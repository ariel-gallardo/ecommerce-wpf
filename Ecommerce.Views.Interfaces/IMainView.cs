using System.Windows;

namespace Ecommerce.IViews
{
    public interface IMainView : IView
    {
        void Show();
        void Hide();
        void Close();
        object DataContext { get; set; }
        event RoutedEventHandler Loaded;
    }
}
