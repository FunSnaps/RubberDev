using Microsoft.Extensions.DependencyInjection;
using RubberDev.Application.Services;
using RubberDev.Application.UseCases;

namespace RubberDev.Infrastructure.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ICartoonCharacterService, CartoonCharacterService>();
        services.AddScoped<IGachaService, GachaService>();
        return services;
    }
}