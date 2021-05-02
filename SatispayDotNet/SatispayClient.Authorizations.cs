using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SatispayDotNet.Models;

namespace SatispayDotNet
{
	public partial class SatispayClient
	{
        public Task<AuthorizationResource> CreateAuthorizationAsync(
            string reason,
            string callbackUrl,
            Dictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
            => SendRequestAsync<AuthorizationResource>(
                _httpClient, HttpMethod.Post, "v1/pre_authorized_payment_tokens", new CreateAuthorizationRequest
                {
                    Reason = reason,
                    CallbackUrl = callbackUrl,
                    Metadata = metadata
                }, cancellationToken);

        public Task<AuthorizationResource> GetAuthorizationAsync(
            string authorizationId,
            CancellationToken cancellationToken = default)
            => SendRequestAsync<AuthorizationResource>(
                _httpClient, HttpMethod.Get, $"v1/pre_authorized_payment_tokens/{authorizationId}", null, cancellationToken);

        public Task<AuthorizationResource> CancelAuthorizationAsync(
            string authorizationId,
            CancellationToken cancellationToken = default)
            => SendUpdateAuthorizationRequestAsync(authorizationId, new CancelAuthorizationRequest(), cancellationToken);

        public Task<AuthorizationResource> AssociateConsumerToAuthorizationAsync(
            string authorizationId,
            string consumerId,
            CancellationToken cancellationToken = default)
            => SendUpdateAuthorizationRequestAsync(authorizationId, new AssociateConsumerToAuthorizationRequest
            {
                ConsumerUid = consumerId
            }, cancellationToken);

        private Task<AuthorizationResource> SendUpdateAuthorizationRequestAsync(
            string authorizationId,
            object requestBody,
            CancellationToken cancellationToken)
            => SendRequestAsync<AuthorizationResource>(
                _httpClient, HttpMethod.Put, $"v1/pre_authorized_payment_tokens/{authorizationId}", requestBody, cancellationToken);
    }
}