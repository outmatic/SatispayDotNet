using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class PaymentDetailsListResource
    {
        [JsonPropertyName("has_more")]
        public bool HasMore { get; set; }
        [JsonPropertyName("data")]
        public List<PaymentDetailsResource> PaymentDetails { get; set; }
    }
}