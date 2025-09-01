using Ecommerce.Common;
using Ecommerce.IViewModels;
using Ecommerce.IViews;

namespace Ecommerce.ViewModels
{
    public class HomeViewModel : ViewModelBase<IHomeView>, IHomeViewModel
    {
        public HomeViewModel(IHomeView homeView) : base(homeView)
        {
        }
    }
}
