using RubberDev.Application.Interfaces;
using RubberDev.Application.Services;

namespace RubberDev.Api.Configurations;

public static class ServiceConfigurations
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICartoonCharacterService, CartoonCharacterService>();
        services.AddScoped<IGachaService, GachaService>();
    }
}