using HelloWorldLibrary.BusinessLogic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UltimateHelloWorld;

// ** args - from static void Main(string[] args) --> Hidden now, but still there
// using - To properly dispose of the 'host' variable at the end
using IHost host = CreateHostBuilder(args).Build();

// Creating a scope for our DI (all app here)
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

// DEPENDENCY INJECTION
try
{
    // Creates a new entry point for this console application
    services.GetRequiredService<App>().Run(args);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    // Create a default host builder (set up with all the default stuff like - path, env variables, etc.)
    // ConfigureServices(Actions, Services) - '_' is the discard character
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            // services --> AddSingleton of Interface/type and an implementation of that type
            services.AddSingleton<IMessages, Messages>();
            services.AddSingleton<App>();
        });
}