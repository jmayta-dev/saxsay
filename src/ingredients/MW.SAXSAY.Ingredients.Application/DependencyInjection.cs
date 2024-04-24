using Microsoft.Extensions.DependencyInjection;

namespace MW.SAXSAY.Ingredients.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        var applicationAssembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(applicationAssembly));

        return services;
    }
}