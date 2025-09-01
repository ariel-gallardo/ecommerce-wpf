using Ecommerce.IViews;
using System.Windows.Controls;

namespace Ecommerce.Views
{
    public partial class LoginView : UserControl, ILoginView
    {
        public LoginView()
        {
            InitializeComponent();
        }
    }
}
