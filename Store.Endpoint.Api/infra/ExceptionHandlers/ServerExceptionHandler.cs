using Store.Endpoint.Api.infra.ExceptionHandlers.Interfaces;
using System.Net;

namespace Store.Endpoint.Api.infra.ExceptionHandlers
{
    public class ServerExceptionHandler: AbstractHandler, IServerExceptionHandler
    {
        private readonly ILogger<ServerExceptionHandler> _logger;
        public ServerExceptionHandler(ILogger<ServerExceptionHandler> logger)
        {
            _logger = logger;
        }

        public ApplicationError Handle(Exception exception)
        {
            if (exception is Exception)
            {
                InitializeError(exception.Message, HttpStatusCode.BadRequest);
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
