using Microsoft.Extensions.DependencyInjection;
using Playground.Infrastructure.Database.Context;

namespace Playground.Infrastructure.CrossCutting.IoC
{
    public static class Bootstrap
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            return services;
        }
    }
}
