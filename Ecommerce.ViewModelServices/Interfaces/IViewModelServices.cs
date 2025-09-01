using Ecommerce.Common;
using Ecommerce.IViews;
using System.ComponentModel;

namespace Ecommerce.ViewModelServices
{
    public interface IViewModelServices : INotifyPropertyChanged
    {
        void ShowMainView();
        IViewModelBase? ViewModel { get; set; }
        void Load();
        void ChangeViewModel(ViewModelEnum vm);
        IView CurrentView { get; set; }
    }
}
