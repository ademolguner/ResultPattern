using ExceptionHandlingResultPattern.Application.Services;
using ExceptionHandlingResultPattern.Filters;
using ExceptionHandlingResultPattern.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddScoped<IPastaService,PastaService>()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers(opt => { opt.Filters.Add(typeof(ExceptionFilterAttribute)); });

var app = builder.Build();
app.UseSwagger()
    .UseSwaggerUI()
    .UseRouting()
    .UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
app.Run();
