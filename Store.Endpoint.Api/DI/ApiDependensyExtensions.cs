using Microsoft.AspNetCore.Mvc;
using Store.Endpoint.Api.infra.SwaggerConfig;
using System.Reflection;

namespace Store.Endpoint.Api.DI
{
    public static class ApiDependensyExtensions
    {
        public static void AddEndpointApi(this IServiceCollection services)
        {
            services.AddApiVersioning(configur =>
            {
                configur.DefaultApiVersion = new ApiVersion(1, 0);
                configur.AssumeDefaultVersionWhenUnspecified = true;
                configur.ReportApiVersions = true;
            });
            services.AddVersionedApiExplorer(setup =>
            {
                setup.GroupNameFormat = "'v'VVV";
                setup.SubstituteApiVersionInUrl = true;
            });
            services.AddSwaggerGen(c =>
            {
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                //c.CustomOperationIds(e => $"{e.ActionDescriptor.RouteValues["controller"]}_{(e.ActionDescriptor as ControllerActionDescriptor).ActionName}");
                //c.CustomOperationIds(e => $"{(e.ActionDescriptor as ControllerActionDescriptor).ActionName}");
            });
            services.ConfigureOptions<ConfigureSwaggerOptions>();
        }
    }
}
