using System;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class AuthenticationResource
    {
        [JsonPropertyName("authentication_key")]
        public AuthenticationKeyResource AuthenticationKey { get; set; }
        [JsonPropertyName("signature")]
        public SignatureResource Signature { get; set; }
        [JsonPropertyName("signed_string")]
        public string SignedString { get; set; }
    }

    public class AuthenticationKeyResource
    {
        [JsonPropertyName("access_key")]
        public string AccessKey { get; set; }
        [JsonPropertyName("customer_uid")]
        public string CustomerUid { get; set; }
        [JsonPropertyName("key_type")]
        public string KeyType { get; set; }
        [JsonPropertyName("auth_type")]
        public string AuthType { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
        [JsonPropertyName("enable")]
        public bool Enable { get; set; }
        [JsonPropertyName("insert_date")]
        public DateTime InsertDate { get; set; }
        [JsonPropertyName("version")]
        public int Version { get; set; }
    }

    public class SignatureResource
    {
        [JsonPropertyName("key_id")]
        public string KeyId { get; set; }
        [JsonPropertyName("algorithm")]
        public string Algorithm { get; set; }
        [JsonPropertyName("headers")]
        public string[] Headers { get; set; }
        [JsonPropertyName("signature")]
        public string Signature { get; set; }
        [JsonPropertyName("resign_required")]
        public bool ResignRequired { get; set; }
        [JsonPropertyName("iteration_count")]
        public int IterationCount { get; set; }
        [JsonPropertyName("valid")]
        public bool Valid { get; set; }
    }
}