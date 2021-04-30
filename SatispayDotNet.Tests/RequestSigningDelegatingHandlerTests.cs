using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SatispayDotNet.Extensions;
using SatispayDotNet.Handlers;
using SatispayDotNet.Models;

namespace SatispayDotNet.Tests
{
    public class RequestSigningDelegatingHandlerTests
    {
        private readonly HttpClient _sut;

        public RequestSigningDelegatingHandlerTests()
        {
            var handler = new RequestSigningDelegatingHandler(Samples.KeyId, Samples.PrivateKey, new FakeDelegatingHandler());

            _sut = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://staging.authservices.satispay.com")
            };
        }

        [Test]
        public async Task RequestSigningDelegatingHandler_AddHeadersWithCorrectDigestAndSignature()
        {
            var body = new TestSignatureRequest
            {
                Flow = "MATCH_CODE",
                AmountUnit = 100,
                Currency = "EUR"
            };

            var request = new HttpRequestMessage(HttpMethod.Get, "/wally-services/protocol/tests/signature")
            {
                Content = body.ToJsonContent()
            };

            request.Headers.Date = new DateTime(2020, 1, 2, 3, 4, 5);

            var _ = await _sut.SendAsync(request);

            var digest = request.Headers.GetValues("Digest").Single();

            Assert.AreEqual(Samples.ExpectedDigest, digest);
            Assert.AreEqual("Signature", request.Headers.Authorization.Scheme);
            Assert.AreEqual(Samples.ExpectedSignature, request.Headers.Authorization.Parameter);
        }
    }
}