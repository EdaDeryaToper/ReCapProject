using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Core.CrossCuttingConcern.Caching;
using Core.CrossCuttingConcern.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache(); //IMemoryCache implementasyonu için
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //security
            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>(); //caching
            serviceCollection.AddSingleton<Stopwatch>(); //performance
        }
    }
}
