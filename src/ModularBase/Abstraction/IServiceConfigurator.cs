using Microsoft.Extensions.DependencyInjection;

namespace ModularBase.Abstraction
{
    public interface IServiceConfigurator
    {
        string ConfiguratorName { get; }
        void RegisterServices(IServiceCollection services);
    }
}