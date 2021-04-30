using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public abstract class BasePaymentRequest
    {
        [JsonPropertyName("flow")]
        public string Flow { get; private set; }
        [JsonPropertyName("amount_unit")]
        public string AmountUnit { get; set; }
        [JsonPropertyName("currency")]
        public string Currency => "EUR";

        public BasePaymentRequest(string flow)
            => Flow = flow;
    }
}