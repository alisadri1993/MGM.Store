using Serilog;
using Store.Business.DI;
using Store.Business.Services;
using Store.DA.DI;
using Store.Endpoint.Api.DI;
using Store.Endpoint.Api.infra.MiddlWares;
using Store.FileManager.DI;


try
{

    var builder = WebApplication.CreateBuilder(args);

    var logConfiguration = new ConfigurationBuilder().AddJsonFile("logsettings.json").Build();
    builder.Host.UseSerilog((ctx, lc) => lc
        .WriteTo.Console()
        .ReadFrom.Configuration(logConfiguration));


    Log.Information("Starting up");

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddEndpointApi();
    builder.Services.AddFileManager(builder.Configuration);
    builder.Services.AddExceptionHandlers();
    builder.Services.AddSwaggerGen();
    //builder.Services.AddSingleton<IProductService, ProductService>();
    builder.Services.AddBusinessDependency();
    builder.Services.AddDADependency();
    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    //app.UseAuthorization();


    app.UseMiddleware<MGMMiddleware>();
    app.UseMiddleware<ExceptionHandlerMiddleware>();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}
