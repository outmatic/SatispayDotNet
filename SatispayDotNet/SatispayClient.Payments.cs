using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SatispayDotNet.Models;

namespace SatispayDotNet
{
    public partial class SatispayClient
    {
        public Task<PaymentDetailsResource> CreatePreauthorizedPaymentAsync(
            string preauthorizedPaymentToken,
            int amountUnit,
            Currency currency,
            string externalCode,
            string callbackUrl,
            Dictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
            => SendCreatePaymentRequestAsync(new CreatePreauthorizedPaymentRequest
            {
                PreAuthorizedPaymentsToken = preauthorizedPaymentToken,
                AmountUnit = amountUnit,
                Currency = currency,
                ExternalCode = externalCode,
                CallbackUrl = callbackUrl,
                Metadata = metadata
            }, cancellationToken);

        public Task<PaymentDetailsResource> CreateMatchUserPaymentAsync(
            string consumerUid,
            int amountUnit,
            Currency currency,
            string externalCode,
            string callbackUrl,
            Dictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
            => SendCreatePaymentRequestAsync(new CreateMatchUserPaymentRequest
            {
                ConsumerUid = consumerUid,
                AmountUnit = amountUnit,
                Currency = currency,
                ExternalCode = externalCode,
                CallbackUrl = callbackUrl,
                Metadata = metadata
            }, cancellationToken);

        public Task<PaymentDetailsResource> CreateMatchCodePaymentAsync(
            int amountUnit,
            Currency currency,
            string externalCode,
            string callbackUrl,
            Dictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
            => SendCreatePaymentRequestAsync(new CreateMatchUserPaymentRequest
            {
                AmountUnit = amountUnit,
                Currency = currency,
                ExternalCode = externalCode,
                CallbackUrl = callbackUrl,
                Metadata = metadata
            }, cancellationToken);

        public Task<PaymentDetailsResource> CreateRefundAsync(
            int amountUnit,
            Currency currency,
            string parentPaymentUid,
            CancellationToken cancellationToken = default)
            => SendCreatePaymentRequestAsync(new CreateRefundRequest
            {
                AmountUnit = amountUnit,
                Currency = currency,
                ParentPaymentUid = parentPaymentUid
            }, cancellationToken);

        public Task<PaymentDetailsResource> GetPaymentDetailsAsync(
            string paymentId,
            CancellationToken cancellationToken = default)
            => SendRequestAsync<PaymentDetailsResource>(_httpClient, HttpMethod.Get, $"v1/payments/{paymentId}", null, cancellationToken);

        public Task<PaymentDetailsListResource> GetPaymentDetailsListAsync(
            Status? status,
            int? limit,
            string startingAfterId,
            DateTime? startingAfterTimestamp,
            CancellationToken cancellationToken = default)
        {
            var queryBuilder = new QueryBuilder();
            if (status.HasValue)
                queryBuilder.Add("status", status.ToString());
            if (limit.HasValue)
                queryBuilder.Add("limit", limit.ToString());
            if (!string.IsNullOrWhiteSpace(startingAfterId))
                queryBuilder.Add("starting_after", startingAfterId);
            if (startingAfterTimestamp.HasValue)
                queryBuilder.Add("starting_after_timestamp", startingAfterTimestamp.Value.Ticks.ToString());

            return SendRequestAsync<PaymentDetailsListResource>(_httpClient, HttpMethod.Get, $"v1/payments?{queryBuilder.GetQuery()}", null, cancellationToken);
        }

        public Task<PaymentDetailsResource> AcceptPaymentAsync(
            string paymentId,
            Dictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
            => SendUpdatePaymentRequestAsync(paymentId, new AcceptPaymentRequest
            {
                Metadata = metadata
            }, cancellationToken);

        public Task<PaymentDetailsResource> CancelPaymentAsync(
            string paymentId,
            Dictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
            => SendUpdatePaymentRequestAsync(paymentId, new CancelPaymentRequest
            {
                Metadata = metadata
            }, cancellationToken);

        public Task<PaymentDetailsResource> CancelOrRefundPaymentAsync(
            string paymentId,
            Dictionary<string, string> metadata = null,
            CancellationToken cancellationToken = default)
            => SendUpdatePaymentRequestAsync(paymentId, new CancelOrRefundPaymentRequest
            {
                Metadata = metadata
            }, cancellationToken);

        private Task<PaymentDetailsResource> SendCreatePaymentRequestAsync(object requestBody, CancellationToken cancellationToken)
            => SendRequestAsync<PaymentDetailsResource>(_httpClient, HttpMethod.Post, "v1/payments", requestBody, cancellationToken);

        private Task<PaymentDetailsResource> SendUpdatePaymentRequestAsync(string paymentId, object requestBody, CancellationToken cancellationToken)
            => SendRequestAsync<PaymentDetailsResource>(_httpClient, HttpMethod.Put, $"v1/payments/{paymentId}", requestBody, cancellationToken);
    }
}