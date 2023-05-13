using DIContainer;
using DIContainer.DependencyInjection;


var services = new DiServiceCollection();

//services.RegisterSingleton<RandomGuidGenerator>();
//services.RegisterTransient<RandomGuidGenerator>();
//services.RegisterSingleton( new RandomGuidGenerator());

services.RegisterTransient<ISomeService, SomeService>();
services.RegisterTransient<IRandomGuidProvider, RandomGuidProvider>();

var container = services.GenerateContainer();

//var service1 = container.GetService<ISomeService>();
//var service2 = container.GetService<ISomeService>();
var mainApp = container.GetService<MainApp>();

await mainApp.StartAsync();