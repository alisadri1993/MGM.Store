using Store.Shared.Models;
using System.Net;

namespace Store.Endpoint.Api.infra.MiddlWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string result = null;
            context.Response.ContentType = "application/json";
            if (exception is StoreException)
            {
                var storeException = (StoreException)exception;
                result = new 
                {
                    Message = storeException.errorType,
                    //StatusCode = HttpStatusCode.BadRequest,
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            else if(exception is Exception)
            {
                result = new 
                {
                    Message = exception.Message,
                    //StatusCode = (int)HttpStatusCode.InternalServerError
                }.ToString();
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            return context.Response.WriteAsync(result);
        }

      
    }
}
