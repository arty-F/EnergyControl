using EnergyControl.Application.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyControl.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            return services;
        }
    }
}
