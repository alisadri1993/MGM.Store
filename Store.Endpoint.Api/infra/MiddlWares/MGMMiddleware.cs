using Store.Shared.Models;
using System.Net;

namespace Store.Endpoint.Api.infra.MiddlWares
{
    public class MGMMiddleware
    {
        private readonly RequestDelegate next;

        public MGMMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
        {
            context.Request.Headers.Add("type", "mgm");

            await next(context);
        }



    }
}
