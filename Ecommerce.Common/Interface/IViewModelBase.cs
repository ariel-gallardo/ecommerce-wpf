using Ecommerce.IViews;
using System.ComponentModel;

namespace Ecommerce.Common
{
    public interface IViewModelBase<V> : IViewModelBase where V : IView
    {
        V View { get; }
        IView ViewChildren { get; set; }
    }

    public interface IViewModelBase : INotifyPropertyChanged
    {
        public dynamic ViewModelServices { get; set; }
    }
}
