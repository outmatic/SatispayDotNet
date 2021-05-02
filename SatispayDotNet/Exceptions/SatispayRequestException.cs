using System;
using System.Net;

namespace SatispayDotNet.Exceptions
{
    public class SatispayRequestException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; }
        public string ErrorCode { get; }
        public string ErrorMessage { get; }

        public SatispayRequestException(
            HttpStatusCode httpStatusCode,
            string errorCode,
            string errorMessage) : base(@$"Failed with HTTP status ""{httpStatusCode}"", error ""{errorCode}"", message ""{errorMessage}""")
        {
            HttpStatusCode = httpStatusCode;
            ErrorCode = errorCode;
            ErrorMessage = errorMessage;
        }
    }
}