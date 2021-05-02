using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    internal class CreateAuthorizationRequest
    {
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}