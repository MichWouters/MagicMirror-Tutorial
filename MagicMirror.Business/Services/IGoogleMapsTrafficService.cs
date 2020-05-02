﻿using MagicMirror.Business.Models;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface ITrafficService
    {
        Task<TrafficModel> GetTrafficModelAsync(string origin, string destination);
    }
}