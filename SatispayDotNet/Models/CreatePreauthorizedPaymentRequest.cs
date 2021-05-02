using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    internal class CreatePreauthorizedPaymentRequest : BaseCreatePaymentRequest
    {
        [JsonPropertyName("pre_authorized_payments_token")]
        public string PreAuthorizedPaymentsToken { get; set; }

        public CreatePreauthorizedPaymentRequest() : base("PRE_AUTHORIZED") { }
    }
}