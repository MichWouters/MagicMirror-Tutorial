using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.ViewModels;
using Windows.UI.Xaml.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace MagicMirror.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        private IMirrorService _service = (Windows.UI.Xaml.Application.Current as App).Container.GetRequiredService<IMirrorService>();

        public MainPage()
        {
            PopulateModel();
            this.InitializeComponent();
        }

        private async void PopulateModel()
        {
            UserSettings settings = UserSettings.GetUserSettings();
            MainViewModel result = await _service.GenerateViewModel(settings);

            DataContext = result;
        }
    }
}