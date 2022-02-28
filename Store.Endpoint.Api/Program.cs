using Store.Business.DI;
using Store.Business.Services;
using Store.Endpoint.Api.DI;
using Store.Endpoint.Api.infra.MiddlWares;
using Store.FileManager.DI;

var builder = WebApplication.CreateBuilder(args);

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
