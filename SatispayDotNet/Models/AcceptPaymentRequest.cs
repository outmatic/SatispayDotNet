namespace SatispayDotNet.Models
{
    internal class AcceptPaymentRequest : BaseUpdatePaymentRequest
    {
        public AcceptPaymentRequest() : base("ACCEPT") { }
    }
}