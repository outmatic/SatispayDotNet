# SatispayDotNet
A modern C# implementation of the [Satispay api](https://developers.satispay.com/reference).

### How do I get started?

Install the nuget package
```
PM> Install-Package SatispayDotNet
```
Then you can register it via the provided extension method:
```
services.AddSatispayClient(keyId, privateKey, production);
```    
Or you can simply create an instance of the SatispayClient class:
```
new SatispayClient(keyId, privateKey, false)
```
To generate the keyId and privateKey, please follow the [documentation](https://developers.satispay.com/reference?showHidden=9ecba#generate-rsa-keys).

N.B. If you use .NET Core 3.1 or earlier, you must pass the private key without the header (-----BEGIN RSA PRIVATE KEY-----) and footer (-----END RSA PRIVATE KEY-----). Pay also attention to line endings, which must be included.

If you want to check if the keys have been setup correctly, you can test the authentication:
```
var authentication = await SatispayClient.TestAuthenticationAsync(keyId, privateKey)
```
If the authentication is successful, you should get both the AuthenticationKeyResource and SignatureResource properties populated. 
```
public class AuthenticationResource
{
    public AuthenticationKeyResource AuthenticationKey { get; set; }
    public SignatureResource Signature { get; set; }
    public string SignedString { get; set; }
}
```
## What's implemented (basically what we needed)
- [x] Authorizations
- [x] Payments
- [x] Consumers
- [ ] Shop Details
- [ ] Fund Lock
- [ ] Merchant Reports

We always welcome pull requests!
