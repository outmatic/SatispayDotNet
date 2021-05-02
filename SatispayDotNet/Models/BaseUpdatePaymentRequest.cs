using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    internal abstract class BaseUpdatePaymentRequest
    {
        [JsonPropertyName("action")]
        public string Action { get; private set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        public BaseUpdatePaymentRequest(string action)
            => Action = action;

    }
}