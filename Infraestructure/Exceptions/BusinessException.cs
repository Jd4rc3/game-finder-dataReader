using System.Net;

namespace Infraestructure.Exceptions;

public class BusinessException : Exception
{
    public HttpStatusCode StatusCode { get; }

    public BusinessException(string message, HttpStatusCode statusCode) : base(message)
    {
        StatusCode = statusCode;
    }
    
}