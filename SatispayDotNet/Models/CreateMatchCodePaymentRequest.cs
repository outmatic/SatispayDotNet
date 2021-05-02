namespace SatispayDotNet.Models
{
    internal class CreateMatchCodePaymentRequest : BaseCreatePaymentRequest
    {
        internal CreateMatchCodePaymentRequest() : base("MATCH_CODE") { }
    }
}