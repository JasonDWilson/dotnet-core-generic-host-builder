using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace jwpro.Common.Helpers.DotNetCore
{
    /// <summary>
    /// IStartup defines the methods that must be present to configure the HostBuilder produced by Generic Host
    /// </summary>
    public interface IStartUp
    {
        void ConfigureApp(HostBuilderContext context, IConfigurationBuilder config);

        void ConfigureHost(IConfigurationBuilder config);

        void ConfigureLogging(HostBuilderContext context, ILoggingBuilder builder);

        void ConfigureServices(HostBuilderContext context, IServiceCollection services);
    }
}
