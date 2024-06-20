
using Common.Logging;
using Serilog;
using Microsoft.EntityFrameworkCore;
using STBEverywhere.API;
using STBEverywhere.Application;
using STBEverywhere.Infrastructure;
using STBEverywhere.Infrastructure.Data;
using STBEverywhere.Application.Comptes.Commands.CreateCompte;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        Log.Logger = new LoggerConfiguration().CreateBootstrapLogger();
        builder.Host.UseSerilog(SeriLogger.Configure);
        //builder.Services.AddTransient<LoggingDelegatingHandler>();  



        // Add services to the container.
        builder.Services
            .AddApplicationServices()
            .AddInfrastructureServices(builder.Configuration)
            .AddApiServices(builder.Configuration)
            .AddControllers(); // Ajoutez cette ligne pour enregistrer les services de contrôleurs



        // Register RabbitMQService
        builder.Services.AddSingleton<RabbitMQService>();

       




        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();
        app.UseApiServices();

        //using (var scope = app.Services.CreateScope())
        //{
        //    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        //    dbContext.Database.Migrate();
        //}

        app.UseHttpsRedirection();

        app.UseSerilogRequestLogging();







        app.MapControllers();



        // app.MapGet("/", () => "Hello World!");


        // Configure the HTTP request pipeline.
        /*app.UseApiServices();

        if (app.Environment.IsDevelopment())
        {
            await app.InitialiseDatabaseAsync();
        }*/
        app.UseRouting();

        app.Run();
    }
}