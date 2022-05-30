using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HepsiTechCase.Console;

public class ServiceProviderFactory
{
    public static IServiceProvider GetServiceProvider()
    {
        IServiceCollection services = new ServiceCollection();
        var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
                      .Select(x => Assembly.Load(AssemblyName.GetAssemblyName(x)));

        services.AddMediatR(assemblies.ToArray());

        return services.BuildServiceProvider();
    }
}