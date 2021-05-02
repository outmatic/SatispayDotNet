using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    internal abstract class BaseCreatePaymentRequest
    {
        [JsonPropertyName("flow")]
        public string Flow { get; private set; }
        [JsonPropertyName("amount_unit")]
        public int AmountUnit { get; set; }
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
        [JsonPropertyName("external_code")]
        public string ExternalCode { get; set; }
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        public BaseCreatePaymentRequest(string flow)
            => Flow = flow;
    }
}