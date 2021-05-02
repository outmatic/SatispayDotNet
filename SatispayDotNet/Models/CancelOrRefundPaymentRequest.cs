namespace SatispayDotNet.Models
{
    internal class CancelOrRefundPaymentRequest : BaseUpdatePaymentRequest
    {
        public CancelOrRefundPaymentRequest() : base("CANCEL_OR_REFUND") { }
    }
}