namespace Store.Endpoint.Api.infra.ExceptionHandlers.Interfaces
{
    public interface IExceptionHandler
    {
        IExceptionHandler SetNext(IExceptionHandler handler);
        ApplicationError Handle(Exception exception);
    }
}
