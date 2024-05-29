using Microsoft.AspNetCore.Builder;
using SMSNotification.Helpers;
using SMSNotification.Services;

var builder = WebApplication.CreateBuilder(args);

// Configurez les services
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddTransient<ISMSService, SMSService>();

// Construisez l'application
var app = builder.Build();

// Configurez le pipeline de requête HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


app.Run();
