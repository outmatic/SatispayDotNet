using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;

namespace SatispayDotNet
{
    internal class QueryBuilder
    {
        private readonly List<KeyValuePair<string, string>> _parameters = new List<KeyValuePair<string, string>>();

        public void Add(string key, string value)
            => _parameters.Add(new KeyValuePair<string, string>(key, value));

        public string GetQuery()
        {
            var encoder = UrlEncoder.Default;
            var flatted = string.Join("&", _parameters.Select(x => $"{encoder.Encode(x.Key)}={encoder.Encode(x.Value)}"));

            return $"{flatted}";
        }
    }
}
