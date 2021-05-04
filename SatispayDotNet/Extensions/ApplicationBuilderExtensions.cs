using Microsoft.Extensions.DependencyInjection;
using SatispayDotNet.Handlers;

namespace SatispayDotNet.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IServiceCollection AddSatispayClient(this IServiceCollection services, string keyId, string privateKey)
        {
            services.AddTransient(s => new SatispayRequestSigningDelegatingHandler(keyId, privateKey));
            services.AddHttpClient<SatispayClient>()
                .AddHttpMessageHandler(s => s.GetService<SatispayRequestSigningDelegatingHandler>());

            return services;
        }
    }
}