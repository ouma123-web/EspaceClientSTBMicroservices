using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STBEverywhere.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            //services.addCarter();

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            //app.MapCarter;

            return app;
        }
    }
}
