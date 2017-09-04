namespace NTS.Data.Packagess
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContextConnector(this IServiceCollection services)
        {
            services.AddScoped<DbContext, Context.NTSContext>();

            return services;
        }
    }
}
