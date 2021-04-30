using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class ConsumerResource
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}