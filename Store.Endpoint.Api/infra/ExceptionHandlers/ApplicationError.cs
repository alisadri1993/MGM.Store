using System.Net;

namespace Store.Endpoint.Api.infra.ExceptionHandlers
{
    public class ApplicationError
    {
        public string Message { get; set; }
        public HttpStatusCode HttpStatusCode { get; set; }
    }
}
