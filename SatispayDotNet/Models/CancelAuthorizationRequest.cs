using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class CancelAuthorizationRequest
    {
        [JsonPropertyName("status")]
        public string Status => "CANCELED";
    }
}