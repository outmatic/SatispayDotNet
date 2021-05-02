using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SatispayDotNet.Tests
{
    public class FakeDelegatingHandler : DelegatingHandler
    {
        private readonly HttpStatusCode _replyWithStatusCode;

        public FakeDelegatingHandler(HttpStatusCode replyWithStatusCode)
            => _replyWithStatusCode = replyWithStatusCode;

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => Task.FromResult(new HttpResponseMessage(_replyWithStatusCode));
    }
}