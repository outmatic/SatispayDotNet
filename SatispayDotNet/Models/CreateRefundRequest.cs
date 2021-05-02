using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    internal class CreateRefundRequest
    {
        [JsonPropertyName("flow")]
        public string Flow => "REFUND";
        [JsonPropertyName("amount_unit")]
        public int AmountUnit { get; set; }
        [JsonPropertyName("parent_payment_uid")]
        public string ParentPaymentUid { get; set; }
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
    }
}