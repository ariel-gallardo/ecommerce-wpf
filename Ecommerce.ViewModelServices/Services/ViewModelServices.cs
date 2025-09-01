using Ecommerce.Application;
using Ecommerce.Application.IServices;
using Ecommerce.Common;
using Ecommerce.IViewModels;
using Ecommerce.IViews;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Ecommerce.ViewModelServices
{
    public class ViewModelServices : IViewModelServices
    {
        #region Private
        private IViewModelBase? _ViewModel;
        private readonly IAuthServices _authServices;
        private readonly IHttpCookieServices _httpCookieServices;
        private readonly IMainViewModel _mainViewModel;
        private readonly IHomeViewModel _homeViewModel;
        private readonly ILoginViewModel _loginViewModel;
        private void AssignViewModelServices(IViewModelServices s)
        {
            _mainViewModel.ViewModelServices = s;
            _homeViewModel.ViewModelServices = s;
            _loginViewModel.ViewModelServices = s;
        }
        #endregion

        public ViewModelServices(
            IAuthServices authServices, 
            IHttpCookieServices httpCookieServices, 
            IMainViewModel mainViewModel, 
            ILoginViewModel loginViewModel, 
            IHomeViewModel homeViewModel)
        {
            _authServices = authServices;
            _httpCookieServices = httpCookieServices;
            _mainViewModel = mainViewModel;
            _mainViewModel.View.DataContext = this;
            _homeViewModel = homeViewModel;
            _loginViewModel = loginViewModel;
            AssignViewModelServices(this);
            Load();
        }

        #region Public
        public IViewModelBase? ViewModel
        {
            get => _ViewModel;
            set
            {
                _ViewModel = value;
                if(ViewModel != null) RaisePropertyChanged();
            }
        }

        private IView _currentView { get; set; }
        public IView CurrentView { get => _currentView; 
            set 
            {
                _currentView = value;
                RaisePropertyChanged();
            } 
        }

        public void Load()
        {
            var cookie = _httpCookieServices.GetCookie("https://reqres.in", "bearer");
            if (cookie != null && !_authServices.IsTokenExpired(cookie))
            {

            }
            else
            {
                ChangeViewModel(ViewModelEnum.Login);
            }
        }
        #endregion

        public event PropertyChangedEventHandler? PropertyChanged;
        public virtual void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ShowMainView()
        {
            _mainViewModel.View.Show();
        }

        public void ChangeViewModel(ViewModelEnum vm)
        {
            switch (vm)
            {
                case ViewModelEnum.Home:
                    CurrentView = _homeViewModel.View;
                    ViewModel = _homeViewModel;
                    break;
                case ViewModelEnum.Login:
                    CurrentView = _loginViewModel.View;
                    ViewModel = _loginViewModel;
                    break;
            }
        }
    }
}
