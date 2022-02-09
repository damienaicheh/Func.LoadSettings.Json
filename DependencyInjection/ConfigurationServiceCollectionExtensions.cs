using Func.LoadSettings.Json.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Func.LoadSettings.Json.DependencyInjection
{
    internal static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MyServerOptions>(config.GetSection(nameof(MyServerOptions)));
            return services;
        }
    }
}