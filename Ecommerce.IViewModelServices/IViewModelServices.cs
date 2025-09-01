using Ecommerce.Common;
using System.ComponentModel;

namespace Ecommerce.ViewModelServices
{
    public interface IViewModelServices : INotifyPropertyChanged
    {
        void ShowMainView();
        IViewModelBase? ViewModel { get; set; }
        Task LoadAsync();
        void ChangeViewModel(ViewModelEnum vm);
        public string Location { get; set; }
    }
}
