namespace SatispayDotNet.Models
{
    internal class CancelPaymentRequest : BaseUpdatePaymentRequest
    {
        public CancelPaymentRequest() : base("CANCEL") { }
    }
}