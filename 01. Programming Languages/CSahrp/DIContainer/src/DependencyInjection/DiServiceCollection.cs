
namespace DIContainer.DependencyInjection;

public class DiServiceCollection
{
    private List<ServiceDescriptor> _serviceDiscriptors = new List<ServiceDescriptor>();

    public DiContainer GenerateContainer()
    {
        return new DiContainer(_serviceDiscriptors);   
    }

    public void RegisterSingleton<TService>(TService implementation)
    {
        _serviceDiscriptors.Add(new ServiceDescriptor(implementation, ServiceLifeTime.Singlton));
    }

    public void RegisterSingleton<TService>()
    {
        _serviceDiscriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Singlton));
    }

    public void RegisterTransient<TService>()
    {
        _serviceDiscriptors.Add(new ServiceDescriptor(typeof(TService), ServiceLifeTime.Transient));
    }

    public void RegisterTransient<TService,TImplementation>() where TImplementation : TService
    {
        _serviceDiscriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Transient));
    }

    public void RegisterSingleton<TService, TImplementation>() where TImplementation : TService
    {
        _serviceDiscriptors.Add(new ServiceDescriptor(typeof(TService), typeof(TImplementation), ServiceLifeTime.Singlton));
    }
}