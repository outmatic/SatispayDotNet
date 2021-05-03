using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SatispayDotNet.Handlers
{
    public class SatispayRequestSigningDelegatingHandler : DelegatingHandler
    {
        private readonly string _keyId;
        private readonly string _privateKey;

        public SatispayRequestSigningDelegatingHandler(
            string keyId,
            string privateKey,
            HttpMessageHandler innerHandler) : base(innerHandler)
        {
            _keyId = keyId;
            _privateKey = privateKey;
        }

        public SatispayRequestSigningDelegatingHandler(
            string keyId,
            string privateKey)
        {
            _keyId = keyId;
            _privateKey = privateKey;
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            await AddDigestHeaderAsync(request);

            AddAuthorizationHeader(request);

            return await base.SendAsync(request, cancellationToken);
        }

        private static async Task AddDigestHeaderAsync(HttpRequestMessage request)
        {
            var body = request.Content != null
                ? await request.Content.ReadAsStringAsync()
                : string.Empty;

            using var sha256 = SHA256.Create();
            var hashed = sha256.ComputeHash(Encoding.UTF8.GetBytes(body));

            request.Headers.Add("Digest", $"SHA-256={Convert.ToBase64String(hashed)}");
        }

        private void AddAuthorizationHeader(HttpRequestMessage request)
        {
            var @string = BuildStringToSign(request);
            var signature = SignData(@string);

            var header = $"keyId=\"{_keyId}\", algorithm=\"rsa-sha256\", headers=\"(request-target) host date digest\", signature=\"{Convert.ToBase64String(signature)}\"";
            request.Headers.Authorization = new AuthenticationHeaderValue("Signature", header);
        }

        private byte[] SignData(string data)
        {
            using var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(_privateKey), out _);

            return rsa.SignData(Encoding.UTF8.GetBytes(data), HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }

        private static string BuildStringToSign(HttpRequestMessage request)
            => new StringBuilder()
                .AppendLine($"(request-target): {request.Method.ToString().ToLowerInvariant()} {request.RequestUri.PathAndQuery}")
                .AppendLine($"host: {request.RequestUri.Host}")
                .AppendLine($"date: {request.Headers.Date?.UtcDateTime.ToString("ddd, dd MMM yyyy HH:mm:ss z")}")
                .Append($"digest: {request.Headers.GetValues("Digest").Single()}")
                .ToString();
    }
}