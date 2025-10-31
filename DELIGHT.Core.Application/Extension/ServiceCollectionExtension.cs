using DELIGHT.Core.Application.Interface.Services;
using DELIGHT.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DELIGHT.Core.Application.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMintService, MintService>();
            return services;
        }
    }
}
