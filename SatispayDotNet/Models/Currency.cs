using System.Text.Json.Serialization;

namespace SatispayDotNet.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Currency
    {
        EUR
    }
}