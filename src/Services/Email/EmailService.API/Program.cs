
using EmailService.API;
//using HealthChecks.UI.Client;
//using Microsoft.AspNetCore.Diagnostics.HealthChecks;


var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<EmailVerificationService>() ;

//builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}




// Get the EmailVerificationService instance from the DI container
var emailVerificationService = app.Services.GetRequiredService<EmailVerificationService>();

// Start listening for messages when the application starts
emailVerificationService.StartListening(numOfConsumers: 3);

app.MapControllers();

//app.MapHealthChecks("/hc", new HealthCheckOptions()
//{
//    Predicate = _ => true,
//    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
//});

app.Run();
