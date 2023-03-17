using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    //herhangi bir interface karşılığını windowsform gibi buradan sağlayabilirsin
    //serviceTool injection yapımızı okumamıza yarar
    public static class ServiceTool
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
