using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    internal class CancelAuthorizationRequest
    {
        [JsonPropertyName("status")]
        public string Status => "CANCELED";
    }
}