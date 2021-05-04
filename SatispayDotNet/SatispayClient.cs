using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using SatispayDotNet.Exceptions;
using SatispayDotNet.Extensions;
using SatispayDotNet.Handlers;
using SatispayDotNet.Models;

namespace SatispayDotNet
{
    public partial class SatispayClient : IDisposable
    {
        private const string ApiUrl = "https://staging.authservices.satispay.com/g_business/";
        private const string SandboxApiUrl = "https://staging.authservices.satispay.com/g_business/";

        private readonly HttpClient _httpClient;

        public SatispayClient(
            string keyId,
            string privateKey,
            bool production)
        {
            _httpClient = BuildClient(keyId, privateKey, production);
        }

        public SatispayClient(
            HttpClient httpClient,
            bool production)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = BuildUri(production);
        }

        public static Task<AuthenticationResource> TestAuthenticationAsync(
            string keyId,
            string privateKey,
            CancellationToken cancellationToken = default)
        {
            var httpClient = BuildClient(keyId, privateKey, false);

            return SendRequestAsync<AuthenticationResource>(
                httpClient, HttpMethod.Post, "/wally-services/protocol/tests/signature", new TestSignatureRequest
                {
                    Flow = "MATCH_CODE",
                    AmountUnit = 100,
                    Currency = "EUR"
                }, cancellationToken);
        }

        private static HttpClient BuildClient(
            string keyId,
            string privateKey,
            bool production)
        {
            var requestSigningHandler = new SatispayRequestSigningDelegatingHandler(keyId, privateKey);

            return new HttpClient(requestSigningHandler)
            {
                BaseAddress = BuildUri(production)
            };
        }

        private static Uri BuildUri(bool production)
            => new Uri(production ? ApiUrl : SandboxApiUrl);

        private static async Task<T> SendRequestAsync<T>(
            HttpClient httpClient,
            HttpMethod httpMethod,
            string requestUri,
            object requestBody,
            CancellationToken cancellationToken)
        {
            var request = new HttpRequestMessage(httpMethod, requestUri);
            if (requestBody != null)
                request.Content = requestBody.ToJsonContent();

            var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            await ThrowErrorIfAnyAsync(response);

            var responseBody = await response.Content.ReadAsStringAsync();

            return responseBody?.Length > 0
                ? JsonSerializer.Deserialize<T>(responseBody)
                : default;
        }

        private static async Task ThrowErrorIfAnyAsync(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
                return;

            var body = await response.Content.ReadAsStringAsync();
            var error = JsonSerializer.Deserialize<SatispayError>(body);

            if (error != null)
                throw new SatispayRequestException(response.StatusCode, error.Code, error.Message);
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}