using Microsoft.Extensions.DependencyInjection;


namespace STBEverywhere.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => {
            //    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            //});

            //services.addCarter();

            return services;
        }

       
    }
}
