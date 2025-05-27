using Microsoft.Extensions.DependencyInjection;
using RubberDev.Application.Interfaces;
using RubberDev.Application.Services;

namespace RubberDev.Infrastructure.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICartoonCharacterService, CartoonCharacterService>();
        services.AddScoped<IGachaService, GachaService>();
        return services;
    }
}