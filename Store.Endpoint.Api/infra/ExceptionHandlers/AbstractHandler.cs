using Store.Endpoint.Api.infra.ExceptionHandlers.Interfaces;
using System.Net;

namespace Store.Endpoint.Api.infra.ExceptionHandlers
{
    public class AbstractHandler : IExceptionHandler
    {
        private IExceptionHandler _nextHandler;
        protected ApplicationError ApplicationError { get; set; }
        public ApplicationError Handle(Exception exception)
        {

            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(exception);
            }
            else
            {
                return null;
            }
        }

        public IExceptionHandler SetNext(IExceptionHandler handler)
        {
            this._nextHandler = handler;

            // Returning a handler from here will let us link handlers in a
            // convenient way like this:
            // monkey.SetNext(squirrel).SetNext(dog);
            return handler;
        }


        protected void InitializeError(string message, HttpStatusCode httpStatusCode)
        {
            ApplicationError = new ApplicationError
            {
                Message = message,
                HttpStatusCode = httpStatusCode
            };
        }
    }
}
