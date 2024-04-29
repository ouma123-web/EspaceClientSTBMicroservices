
using STBEverywhere.API;
using STBEverywhere.Application;
using STBEverywhere.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices();
    



var app = builder.Build();



// app.MapGet("/", () => "Hello World!");


// Configure the HTTP request pipeline.

app.Run();
