using Microsoft.Extensions.DependencyInjection;
using RubberDev.Application.Interfaces;
using RubberDev.Infrastructure.Brokers;

namespace RubberDev.Infrastructure.Configurations;

public static class BrokerConfigurations
{
    public static IServiceCollection AddBrokers(this IServiceCollection services)
    {
        services.AddScoped<IStorageBroker, StorageBroker>();
        return services;
    }
}