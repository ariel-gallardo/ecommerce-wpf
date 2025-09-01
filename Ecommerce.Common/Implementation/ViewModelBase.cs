using Ecommerce.IViews;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ecommerce.Common
{
    public abstract class ViewModelBase<T> : IViewModelBase<T> where T : IView
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private readonly T _view;
        public T View => _view;

        private IView? _viewChildren;
        public IView? ViewChildren
        {
            get => _viewChildren;
            set
            {
                _viewChildren = value;
                RaisePropertyChanged();
            }
        }

        private dynamic _viewModelServices;
        public dynamic ViewModelServices
        {
            get => _viewModelServices; 
            set { _viewModelServices = value; } 
        }

        public ViewModelBase(T view)
        {
            _view = view;
        }
    }
}
