using AutoMapper;
using MagicMirror.Business.Models;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp.Converters
{
    public class TrafficModelToMainViewModel : ITypeConverter<TrafficModel, MainViewModel>
    {
        public MainViewModel Convert(TrafficModel source, MainViewModel destination, ResolutionContext context)
        {
            destination.TimeOfArrival = source.TimeOfArrival.ToLocalTime().ToShortTimeString();
            destination.TravelTime = GetHoursAndMinutes(source.Duration);

            return destination;
        }

        private string GetHoursAndMinutes(int duration)
        {
            int hours = duration / 60;
            int minutes = duration % 60;

            if (hours > 0)
            {
                return $"{hours} hours and {minutes} minutes";
            }
            else
            {
                return $"{minutes} minutes";
            }
        }
    }
}