using DELIGHT.Core.Application.Interface.Repositories;
using DELIGHT.Infraestructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DELIGHT.Infraestructure.Persistence.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPersistenceInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IMintRepository, MintRepository>();
            return services;
        }
    }
}
