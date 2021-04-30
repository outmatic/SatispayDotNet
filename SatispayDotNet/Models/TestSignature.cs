using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class TestSignatureRequest
    {
        [JsonPropertyName("flow")]
        public string Flow { get; set; }
        [JsonPropertyName("amount_unit")]
        public int AmountUnit { get; set; }
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
    }
}