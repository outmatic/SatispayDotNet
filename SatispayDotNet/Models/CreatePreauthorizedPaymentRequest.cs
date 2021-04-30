using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class CreatePreauthorizedPaymentRequest : BasePaymentRequest
    {
        [JsonPropertyName("pre_authorized_payments_token")]
        public string PreAuthorizedPaymentsToken { get; set; }
        [JsonPropertyName("external_code")]
        public string ExternalCode { get; set; }
        [JsonPropertyName("callback_url")]
        public string CallbackUrl { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        public CreatePreauthorizedPaymentRequest() : base("PRE_AUTHORIZED") { }
    }

    public class PaymentResource
    {
        public string Id { get; set; }
        public string CodeIdentifier { get; set; }
        public string Type { get; set; }
        public int AmountUnit { get; set; }
        public string Currency { get; set; }
        public string Status { get; set; }
        public bool Expired { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

    }

    /*
     {
  "id": "41da7b74-a9f4-4d25-8428-0e3e460d90c1",
  "code_identifier": "S6Y-PAY--41DA7B74-A9F4-4D25-8428-0E3E460D90C1",    
  "type": "TO_BUSINESS",
  "amount_unit": 100,
  "currency": "EUR",
  "status": "ACCEPTED",
  "expired": false,
  "metadata": {
    "order_id": "my_order_id",
    "user":"my_user_id",
    "payment_id":"my_payment",
    "session_id":"my_session",
    "key": "value"
  },
  "sender": {
    "id": "efe81246-eb8a-11e5-95cc-06cb0bb44fdf",
    "type": "CONSUMER",
    "name": "Massimo S."
  },
  "receiver": {
    "id": "9b14338e-428e-4942-ab7a-3291f3792e56",
    "type": "SHOP"
  },  
  "daily_closure": {
    "id": "20190707",
    "date": "2019-07-07T00:00:00.000Z"
  },
  "insert_date": "2019-07-07T09:00:22.814Z",
  "expire_date": "2019-07-07T09:15:22.807Z",
  "external_code": "my_order_id"
}
     */
}