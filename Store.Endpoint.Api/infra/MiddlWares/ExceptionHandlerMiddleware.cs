using Newtonsoft.Json;
using Store.Endpoint.Api.infra.ExceptionHandlers.Interfaces;
using Store.Shared.Models;
using System.Net;

namespace Store.Endpoint.Api.infra.MiddlWares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IStoreExceptionHandler _storeExceptionHandler;
        private readonly IServerExceptionHandler _serverExceptionHandler;
        private readonly IExceptionHandler exceptionHandler;

        public ExceptionHandlerMiddleware(RequestDelegate next,
                                          IStoreExceptionHandler storeExceptionHandler,
                                          IServerExceptionHandler serverExceptionHandler)
        {
            this.next = next;
            _storeExceptionHandler = storeExceptionHandler;
            _serverExceptionHandler = serverExceptionHandler;
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
            
            _storeExceptionHandler.SetNext(_serverExceptionHandler);
            var appError =  _storeExceptionHandler.Handle(exception);
            context.Response.StatusCode = (int)appError.HttpStatusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(appError));

/*
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

            return context.Response.WriteAsync(result);*/
        }

      
    }
}
