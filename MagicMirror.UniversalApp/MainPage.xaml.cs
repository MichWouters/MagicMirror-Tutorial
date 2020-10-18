using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.Services;
using MagicMirror.UniversalApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Windows.UI.Xaml.Controls;

namespace MagicMirror.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        private IMirrorService _service = (Windows.UI.Xaml.Application.Current as App).Container.GetRequiredService<IMirrorService>();

        public MainPage()
        {
            //PopulateModel();
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