using Ecommerce.Common;
using Ecommerce.IViewModels;
using Ecommerce.IViews;

namespace Ecommerce.ViewModels
{
    public class MainViewModel : ViewModelBase<IMainView>, IMainViewModel
    {
        public MainViewModel(IMainView view) : base(view)
        {
            
        }
    }
}
