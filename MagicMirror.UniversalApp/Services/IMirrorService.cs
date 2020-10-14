using MagicMirror.UniversalApp.Models;
using MagicMirror.UniversalApp.ViewModels;
using System.Threading.Tasks;

namespace MagicMirror.UniversalApp.Services
{
    public interface IMirrorService
    {
        Task<MainViewModel> GenerateViewModel(UserSettings information);
    }
}