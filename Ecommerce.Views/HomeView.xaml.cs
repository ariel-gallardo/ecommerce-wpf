using Ecommerce.IViews;
using System.Windows.Controls;

namespace Ecommerce.Views
{
    public partial class HomeView : UserControl, IHomeView
    {
        public HomeView()
        {
            InitializeComponent();
        }
    }
}
