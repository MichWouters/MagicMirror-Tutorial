using System.Threading.Tasks;
using MagicMirror.ConsoleApp.Models;

namespace MagicMirror.ConsoleApp
{
    public interface IMagicMirrorApp
    {
        Task<MainViewModel> GenerateViewModel(UserInformation information);
        Task RunAsync();
    }
}