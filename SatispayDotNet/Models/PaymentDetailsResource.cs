using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    public class PaymentDetailsResource
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }
        [JsonPropertyName("code_identifier")]
        public string CodeIdentifier { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("amount_unit")]
        public int AmountUnit { get; set; }
        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("expired")]
        public bool Expired { get; set; }
        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
        [JsonPropertyName("sender")]
        public SenderResource Sender { get; set; }
        [JsonPropertyName("receiver")]
        public ReceiverResource Receiver { get; set; }
        [JsonPropertyName("daily_closure")]
        public DailyClosureResource DailyClosure { get; set; }
        [JsonPropertyName("insert_date")]
        public DateTime InsertDate { get; set; }
        [JsonPropertyName("expire_date")]
        public DateTime ExpireDate { get; set; }
        [JsonPropertyName("external_code")]
        public string ExternalCode { get; set; }

        public class SenderResource
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("type")]
            public string Type { get; set; }
            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        public class ReceiverResource
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }

        public class DailyClosureResource
        {
            [JsonPropertyName("id")]
            public string Id { get; set; }
            [JsonPropertyName("type")]
            public string Type { get; set; }
        }
    }
}