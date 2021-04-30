using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SatispayDotNet.Extensions;
using SatispayDotNet.Handlers;
using SatispayDotNet.Models;

namespace SatispayDotNet
{
    public class SatispayClient : IDisposable
    {
        private const string ApiUrl = "https://staging.authservices.satispay.com/g_business/";
        private const string SandboxApiUrl = "https://staging.authservices.satispay.com/g_business/";

        private readonly HttpClient _httpClient;

        public SatispayClient(string keyId, string privateKey, bool production)
        {
            _httpClient = BuildClient(keyId, privateKey, production
                ? ApiUrl
                : SandboxApiUrl);
        }

        public static Task<AuthenticationResource> TestAuthenticationAsync(string keyId, string privateKey)
        {
            var httpClient = BuildClient(keyId, privateKey, SandboxApiUrl);

            return SendRequestAsync<AuthenticationResource>(
                httpClient, HttpMethod.Post, "/wally-services/protocol/tests/signature", new TestSignatureRequest
                {
                    Flow = "MATCH_CODE",
                    AmountUnit = 100,
                    Currency = "EUR"
                });
        }

        private static HttpClient BuildClient(string keyId, string privateKey, string apiUrl)
        {
            var requestSigningHandler = new RequestSigningDelegatingHandler(keyId, privateKey);

            return new HttpClient(requestSigningHandler)
            {
                BaseAddress = new Uri(apiUrl)
            };
        }

        #region Consumers
        public Task<ConsumerResource> GetConsumer(string phoneNumber)
            => SendRequestAsync<ConsumerResource>(
                _httpClient, HttpMethod.Get, $"v1/consumers/{phoneNumber}");
        #endregion

        #region Authorizations
        public Task<AuthorizationResource> CreateAuthorizationAsync(string reason, string callbackUrl, Dictionary<string, string> metadata)
            => SendRequestAsync<AuthorizationResource>(
                _httpClient, HttpMethod.Post, "v1/pre_authorized_payment_tokens", new CreateAuthorizationRequest
                {
                    Reason = reason,
                    CallbackUrl = callbackUrl,
                    Metadata = metadata
                });

        public Task<AuthorizationResource> GetAuthorizationAsync(string authorizationId)
            => SendRequestAsync<AuthorizationResource>(
                _httpClient, HttpMethod.Get, $"v1/pre_authorized_payment_tokens/{authorizationId}");

        public Task<AuthorizationResource> CancelAuthorizationAsync(string authorizationId)
            => SendRequestAsync<AuthorizationResource>(
                _httpClient, HttpMethod.Put, $"v1/pre_authorized_payment_tokens/{authorizationId}", new CancelAuthorizationRequest());

        public Task<AuthorizationResource> AssociateConsumerToAuthorizationAsync(string authorizationId, string consumerId)
            => SendRequestAsync<AuthorizationResource>(
                _httpClient, HttpMethod.Put, $"v1/pre_authorized_payment_tokens/{authorizationId}", new AssociateConsumerToAuthorizationRequest
                {
                    ConsumerUid = consumerId
                });
        #endregion

        #region Payments

        #endregion
        private static async Task<T> SendRequestAsync<T>(HttpClient httpClient, HttpMethod httpMethod, string requestUri, object body = null)
        {
            var request = new HttpRequestMessage(httpMethod, requestUri);
            if (body != null)
                request.Content = body.ToJsonContent();

            var response = await httpClient.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                // todo throw correct exception
                throw new Exception();

            var json = await response.Content.ReadAsStringAsync();

            if (json.Length == 0)
                return default;

            return JsonSerializer.Deserialize<T>(json);
        }

        public void Dispose() => _httpClient?.Dispose();
    }
}
