using RubberDev.Application.Services;
using RubberDev.Application.UseCases;

namespace RubberDev.Api.Configurations;

public static class ServiceConfigurations
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICartoonCharacterService, CartoonCharacterService>();
        services.AddScoped<IGachaService, GachaService>();
    }
}