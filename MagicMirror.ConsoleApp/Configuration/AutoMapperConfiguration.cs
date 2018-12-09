using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MagicMirror.ConsoleApp.Configuration
{
    public static class AutoMapperConfiguration
    {
        public static void RegisterMaps()
        {
            Mapper.Initialize(config =>
            {

            });
        }
    }
}
