using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class AuthorizationResource
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("code_identifier")]
        public string CodeIdentifier { get; set; }
        [JsonPropertyName("shop_uid")]
        public string ShopUid { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("reason")]
        public string Reason { get; set; }
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}