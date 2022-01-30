using ClusterService.Api.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApiContrib.Core.Formatter.Protobuf;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddProtobufFormatters();

builder.Services
    .AddEndpointsApiExplorer();
builder.Services
    .AddSwaggerGen();

builder.Services
    .AddScoped<SqlConnection>(sp => new SqlConnection(builder.Configuration["ConnectionStrings:SqlDb"]));
builder.Services
    .AddScoped<ILeaseRepository, LeaseRepository>();

builder.Services
    .AddSingleton<ITimeService, TimeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
