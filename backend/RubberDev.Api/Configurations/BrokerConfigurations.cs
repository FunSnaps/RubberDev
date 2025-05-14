using RubberDev.Brokers;
using RubberDev.Infrastructure;

namespace RubberDev.Api.Configurations;

public static class BrokerConfigurations
{
    public static void AddBrokers(this IServiceCollection services)
    {
        services.AddScoped<IStorageBroker, StorageBroker>();
    }
}