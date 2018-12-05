# DotNetCore.GenericHost
Attempts to bring consistency to the Core GenericHost when compared to the WebHost.  It allows passing of a Startup class when building the host.


This project tries to bring consistency to using the .Net Core Generic Host when compared to using the Web Host. It brings with it the ability to pass a StartUp class that will be used to configure the host, hosted applications, dependency injection services, and logging.

In order to use the project:

1) Make a reference to it (duh).
2) Create a class that implements IStartup.
3) In your application root call GenericHost.CreateDefaultBuilder() and GenericHost.UseStartUp() like in this example
    public class Program
    {

        public static IHost BuildHost(string[] args) =>
            GenericHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();

        public static async Task Main(string[] args)
        {
            var host = BuildHost(args);
            await host.StartAsync();
            await host.StopAsync();
            host.Dispose();
        }
    }
