using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    internal class CreateMatchUserPaymentRequest : BaseCreatePaymentRequest
    {
        [JsonPropertyName("consumer_uid")]
        public string ConsumerUid { get; set; }

        public CreateMatchUserPaymentRequest() : base("MATCH_USER") { }
    }
}