using MagicMirror.UniversalApp.Resources;
using System;

namespace MagicMirror.UniversalApp.Services
{
    public class ComplimentService : IComplimentService
    {
        public string GenerateCompliment()
        {
            var compRepo = new ComplimentRepo().GetCompliments();
            int randomId = new Random().Next(compRepo.Count);

            return compRepo[randomId];
        }
    }
}