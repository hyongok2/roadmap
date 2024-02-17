// See https://aka.ms/new-console-template for more information
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

Console.WriteLine("Hello, World!");

IHost host = Host.CreateDefaultBuilder().ConfigureServices(services => 
{
    AddServiceDependency(services);
}).Build();



var app = host.Services.GetService<IApplication>();
app!.StartAsync();

void AddServiceDependency(IServiceCollection services)
{
    services.AddSingleton<IApplication, Application>();
    services.AddSingleton<ILogger<Application>, MyLogger>();
}