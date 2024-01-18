using System;
using System.Net;

namespace NSE.WebApp.MVC.Extensions
{
    public class CustomHttpResponseException : Exception
    {
        public HttpStatusCode _statusCode;

        public CustomHttpResponseException()
        {

        }

        public CustomHttpResponseException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public CustomHttpResponseException(HttpStatusCode statusCode)
        {
            _statusCode = statusCode;
        }
    }
}
