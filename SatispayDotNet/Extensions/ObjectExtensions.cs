using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace SatispayDotNet.Extensions
{
    public static class ObjectExtensions
    {
        public static HttpContent ToJsonContent(this object obj, bool indented = true)
            => new StringContent(JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = indented
            }), Encoding.UTF8, "application/json");
    }
}