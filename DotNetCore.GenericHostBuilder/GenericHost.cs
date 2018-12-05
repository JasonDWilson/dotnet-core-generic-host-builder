using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

namespace ARA.Applications.Common.Helpers.DotNetCore
{
    /// <summary>
    /// GenericHost class is used to replicate the configuration of Microsoft's WebHost
    /// in that you can pass it a Startup Class to configure the host and application
    /// </summary>
    public static class GenericHost
    {
        public static IHostBuilder CreateDefaultBuilder(string[] args)
        {
            var builder = new HostBuilder();

            if (args != null)
            {
                builder.ConfigureHostConfiguration(configHost =>
                {
                    configHost.AddCommandLine(args);
                });
                builder.ConfigureAppConfiguration((hostContext, configApp) =>
                {
                    configApp.AddCommandLine(args);
                });
            }
            return builder;
        }

        public static IHostBuilder UseStartup<TStartupType>(this IHostBuilder builder) where TStartupType : IStartUp
        {
            var startup = (TStartupType)Activator.CreateInstance(typeof(TStartupType));
            builder.ConfigureHostConfiguration(startup.ConfigureHost);
            builder.ConfigureAppConfiguration(startup.ConfigureApp);
            builder.ConfigureServices(startup.ConfigureServices);
            builder.ConfigureLogging(startup.ConfigureLogging);
            return builder;
        }

    }
}
