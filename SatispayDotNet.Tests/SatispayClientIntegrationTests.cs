using System.Collections.Generic;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SatispayDotNet.Tests
{
    public class SatispayClientIntegrationTests
    {
        private readonly SatispayClient _sut;

        public SatispayClientIntegrationTests()
            => _sut = new SatispayClient(Samples.KeyId, Samples.PrivateKey, false);

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

            var authorization = await _sut.CreateAuthorizationAsync(reason, callbackUrl, metadata);

            Assert.IsNotEmpty(authorization.Id);
            Assert.IsNotEmpty(authorization.CodeIdentifier);
            Assert.AreEqual(reason, authorization.Reason);
            Assert.AreEqual(callbackUrl, authorization.CallbackUrl);
            Assert.AreEqual(metadata.Count, authorization.Metadata.Count);
        }

        [Test]
        [Ignore("the server responds 500")]
        public async Task SatispayClient_CreatesMatchCodePayment()
        {
            var order = new Samples.SampleOrder();

            var callbackUrl = "https://example.domain";
            var metadata = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var payment = await _sut.CreateMatchCodePaymentAsync(100 * order.Amount, order.Currency, order.Id, callbackUrl, metadata);

            Assert.IsNotEmpty(payment.Id);
            Assert.IsNotEmpty(payment.CodeIdentifier);
            Assert.AreEqual(metadata.Count, payment.Metadata.Count);
        }

        [Test]
        public async Task SatispayClient_CreatesMatchUserPayment()
        {
            var order = new Samples.SampleOrder();

            var callbackUrl = "https://example.domain";
            var metadata = new Dictionary<string, string>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            var payment = await _sut.CreateMatchUserPaymentAsync("1a310721-1a09-45d2-8403-a75ce398f820", 100 * order.Amount, order.Currency, order.Id, callbackUrl, metadata);

            Assert.IsNotEmpty(payment.Id);
            Assert.AreEqual(metadata.Count, payment.Metadata.Count);
        }

        [Test]
        public async Task SatispayClient_GetsConsumer()
        {
            var consumer = await _sut.GetConsumerAsync("+393770816896");

            Assert.IsNotEmpty(consumer.Id);
        }
    }
}