using RubberDev.Services;
using RubberDev.Services.Interfaces;

namespace RubberDev.Api.Configurations;

public static class ServiceConfigurations
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICartoonCharacterService, CartoonCharacterService>();
    }
}