using Microsoft.Extensions.DependencyInjection;

namespace EnergyControl.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<EnergyControlContext>();
            return services;
        }
    }
}
