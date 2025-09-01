using Ecommerce.Common;
using Ecommerce.Common.DTOs;
using Ecommerce.IViewModels;
using Ecommerce.Views;
using Ecommerce.IViews;
using System.ComponentModel;
using Ecommerce.ViewModelServices;

namespace Ecommerce.ViewModels
{
    public class LoginViewModel : ViewModelBase<ILoginView>, ILoginViewModel
    {
        #region Private
        private readonly AsyncDelegateCommand _loginCommand;
        private readonly IViewModelServices _viewModelServices;

        private bool CanLogin(LoginDTO dto) => !string.IsNullOrWhiteSpace(dto.Username) && !string.IsNullOrWhiteSpace(dto.Password);
        private void OnDtoChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(LoginDTO.Username) ||
                e.PropertyName == nameof(LoginDTO.Password))
            {
                LoginCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion
        public LoginDTO LoginDTO { get; set; }
        public LoginViewModel(ILoginView view) : base(view)
        {
            LoginDTO = new LoginDTO();
            _loginCommand = new AsyncDelegateCommand(_ => Login(LoginDTO),_ => CanLogin(LoginDTO));
            LoginDTO.PropertyChanged += OnDtoChanged;
        }
        public AsyncDelegateCommand LoginCommand => _loginCommand;

        public async Task Login(LoginDTO dto)
        {
            if(ViewModelServices is IViewModelServices vMS)
            {
                vMS.ChangeViewModel(ViewModelEnum.Home);
            }
        }
    }
}
