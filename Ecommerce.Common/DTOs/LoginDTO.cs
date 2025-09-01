using System.Windows.Documents;

namespace Ecommerce.Common.DTOs
{
    public class LoginDTO : DTO
    {
        #region Private
        private string username;
        private string password;
        #endregion

        #region Public
        public string Username
        {
            get => username;
			set => SetProperty(ref username, value);
		}
        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }
        #endregion
    }
}
