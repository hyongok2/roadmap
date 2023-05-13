using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer.DependencyInjection;

public class DiContainer
{
    private List<ServiceDescriptor> _serviceDiscriptors;

    public DiContainer(List<ServiceDescriptor> serviceDiscriptors)
    {
        _serviceDiscriptors = serviceDiscriptors;
    }

    public object GetService(Type serviceType)
    {
        var descriptor = _serviceDiscriptors.FirstOrDefault(x => x.ServiceType == serviceType);

        if (descriptor == null)
        {
            throw new Exception($"Service of type {serviceType.Name} isn't registered");
        }

        if (descriptor.Implementation != null)
        {
            return descriptor.Implementation;
        }

        var actualType = descriptor.ImplementationType ?? descriptor.ServiceType;

        if (actualType.IsInterface || actualType.IsAbstract)
        {
            throw new Exception("Cannot instantiate interfaces or abstract classes");
        }

        var contructorInfo = actualType.GetConstructors().First();

        var parameters = contructorInfo.GetParameters().Select(x => GetService(x.ParameterType)).ToArray();

        var implementation = Activator.CreateInstance(actualType, parameters)!;

        if (descriptor.LifeTime == ServiceLifeTime.Singlton)
        {
            descriptor.Implementation = implementation;
        }

        return implementation;
    }

    public T GetService<T>()
    {
        return (T)GetService(typeof(T));
    }
}
