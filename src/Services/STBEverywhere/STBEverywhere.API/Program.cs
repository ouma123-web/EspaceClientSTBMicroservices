using STBEverywhere.API;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddApplicationServices(builder.Configuration)
    .AddInfrastructureServices(builder.Configuration)
    .AddApiServices(builder.Configuration);



var app = builder.Build();



// app.MapGet("/", () => "Hello World!");


// Configure the HTTP request pipeline.

app.Run();
