using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using SatispayDotNet.Models;

namespace SatispayDotNet
{
	public partial class SatispayClient
	{
        public Task<ConsumerResource> GetConsumerAsync(
            string phoneNumber,
            CancellationToken cancellationToken = default)
            => SendRequestAsync<ConsumerResource>(_httpClient, HttpMethod.Get, $"v1/consumers/{phoneNumber}", null, cancellationToken);
	}
}