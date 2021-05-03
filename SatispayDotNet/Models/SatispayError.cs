using System.Text.Json.Serialization;

namespace SatispayDotNet
{
    public class SatispayError
    {
        [JsonPropertyName("code")]
        public int Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}