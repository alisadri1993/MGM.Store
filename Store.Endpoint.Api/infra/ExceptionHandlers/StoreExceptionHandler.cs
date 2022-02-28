using Store.Endpoint.Api.infra.ExceptionHandlers.Interfaces;
using Store.Shared.Models;
using System.Net;

namespace Store.Endpoint.Api.infra.ExceptionHandlers
{
    public class StoreExceptionHandler: AbstractHandler, IStoreExceptionHandler
    {
        private readonly ILogger<StoreExceptionHandler> _logger;

        public StoreExceptionHandler(ILogger<StoreExceptionHandler> logger)
        {
            _logger = logger;
        }

        public ApplicationError Handle(Exception exception)
        {
            if (exception is StoreException )
            {
                var appExcption = ((StoreException)exception);
                InitializeError(appExcption.Message, HttpStatusCode.InternalServerError);
                
                _logger.LogError(exception.ToString());
                return ApplicationError;
            }
            else
            {
                return base.Handle(exception);
            }
        }
    }
}
