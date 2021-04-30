using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SatispayDotNet.Tests
{
    public class SatispayClientIntegrationTests
    {
        private readonly SatispayClient _sut;

        public SatispayClientIntegrationTests()
        {
            _sut = new SatispayClient(Samples.KeyId, Samples.PrivateKey, false);
        }

        [Test]
        public async Task SatispayClient_PerformsAuthentication()
        {
            var authentication = await SatispayClient.TestAuthenticationAsync(Samples.KeyId, Samples.PrivateKey);
            Assert.IsNotNull(authentication);
            Assert.IsTrue(authentication.Signature.Valid);
        }

        [Test]
        public async Task SatispayClient_CreatesAuthorization()
        {
            var reason = "Monthly bill";
            var callbackUrl = "https://example.domain";
            var metadata = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var response = await _sut.CreateAuthorizationAsync(reason, callbackUrl, metadata);

            Assert.IsNotEmpty(response.Id);
            Assert.IsNotEmpty(response.CodeIdentifier);
            Assert.AreEqual(reason, response.Reason);
            Assert.AreEqual(callbackUrl, response.CallbackUrl);
            Assert.AreEqual(metadata.Count, response.Metadata.Count);
        }
    }
}