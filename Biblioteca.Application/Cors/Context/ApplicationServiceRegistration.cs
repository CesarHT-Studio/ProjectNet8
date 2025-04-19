using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Application.Cors.Context;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        //configuracion de automaper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }
}