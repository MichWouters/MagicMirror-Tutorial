using System.Collections.ObjectModel;
using MagicMirror.UniversalApp.ViewModels;
using Windows.UI.Xaml.Controls;

namespace MagicMirror.UniversalApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            PopulateModel();
            this.InitializeComponent();
            UpcomingDaysList.ItemsSource = this.GetDays();
        }

        private void PopulateModel()
        {
            DataContext = new MainViewModel();
        }

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