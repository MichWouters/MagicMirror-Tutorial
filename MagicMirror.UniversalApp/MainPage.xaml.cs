using MagicMirror.UniversalApp.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MagicMirror.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel = new MainViewModel();

        public MainPage()
        {
            DataContext = new MainViewModel();
            this.InitializeComponent();
        }
    }
}