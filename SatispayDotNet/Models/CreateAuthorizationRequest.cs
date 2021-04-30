using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class CreateAuthorizationRequest
    {
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }

    public abstract class BasePaymentRequest
    {
        [JsonPropertyName("flow")]
        public string Flow { get; internal set; }
        [JsonPropertyName("amount_unit")]
        public string AmountUnit { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        public BasePaymentRequest(string flow)
            => Flow = flow;
    }

    public class CreatePreauthorizedPaymentRequest : BasePaymentRequest
    {
        [JsonPropertyName("pre_authorized_payments_token")]
        public string PreAuthorizedPaymentsToken { get; set; }
        [JsonPropertyName("external_code")]
        public string ExternalCode { get; set; }
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        public CreatePreauthorizedPaymentRequest() : base("PRE_AUTHORIZED") { }
    }
}