using MagicMirror.UniversalApp.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace MagicMirror.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            _ = PopulateModel();
            this.InitializeComponent();
            UpcomingDaysList.ItemsSource = this.GetDays();
        }

        private async Task PopulateModel()
        {
            var vm = new MainViewModel();
            await vm.InitializeAsync();
            DataContext = vm;
        }

        // TODO: Use actual data
        private ObservableCollection<UpcomingDay> GetDays()
        {
            return new ObservableCollection<UpcomingDay>
            {
                new UpcomingDay("Tue", "", 80, 69),
                new UpcomingDay("Wed", "", 82, 56),
                new UpcomingDay("Thu", "", 78, 50),
                new UpcomingDay("Fri", "", 77, 52),
            };
        }
    }
}