using Ecommerce.Common;
using Ecommerce.IViews;

namespace Ecommerce.IViewModels
{
    public interface ILoginViewModel : IViewModelBase<ILoginView>
    {
        AsyncDelegateCommand LoginCommand { get; }
    }
}
