using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class AssociateConsumerToAuthorizationRequest
    {
        [JsonPropertyName("consumer_uid")]
        public string ConsumerUid { get; set; }
    }
}