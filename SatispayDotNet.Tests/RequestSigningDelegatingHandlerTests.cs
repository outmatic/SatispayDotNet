using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;
using SatispayDotNet.Extensions;
using SatispayDotNet.Handlers;

namespace SatispayDotNet.Tests
{
    public class RequestSigningDelegatingHandlerTests
    {
        private readonly HttpClient _sut;

        public RequestSigningDelegatingHandlerTests()
        {
            var handler = new SatispayRequestSigningDelegatingHandler(Samples.KeyId, Samples.PrivateKey, new FakeDelegatingHandler(HttpStatusCode.OK));

            _sut = new HttpClient(handler)
            {
                BaseAddress = new Uri("https://staging.authservices.satispay.com")
            };
        }

        [Test]
        public async Task RequestSigningDelegatingHandler_TestWithEmptyBody()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/wally-services/protocol/tests/signature");

            request.Headers.Date = new DateTime(2020, 1, 2, 3, 4, 5);

            var _ = await _sut.SendAsync(request);

            var digest = request.Headers.GetValues("Digest").Single();

            Assert.AreEqual(Samples.ExpectedEmptyBodyDigest, digest);
            Assert.AreEqual("Signature", request.Headers.Authorization.Scheme);
            Assert.AreEqual(Samples.ExpectedEmptyBodySignature, request.Headers.Authorization.Parameter);
        }

        [Test]
        public async Task RequestSigningDelegatingHandler_AddHeadersWithCorrectDigestAndSignature()
        {
            var body = new Samples.SampleRequest
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