using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using SatispayDotNet.Handlers;

namespace SatispayDotNet.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IServiceCollection AddSatispayClient(this IServiceCollection services, string keyId, string privateKey, bool production)
        {
            services.AddHttpClient("SatispayClient")
                .AddHttpMessageHandler(c => new SatispayRequestSigningDelegatingHandler(keyId, privateKey));

            services.AddTransient(c =>
            {
                var clientFactory = c.GetRequiredService<IHttpClientFactory>();
                var httpClient = clientFactory.CreateClient("SatispayClient");

                return new SatispayClient(httpClient, production);
            });

            return services;
        }
    }
}