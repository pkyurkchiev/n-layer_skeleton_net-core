namespace NTS.Repositories.Packagess
{
    using Data.Packagess;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositoryConnector(this IServiceCollection services)
        {
            services.AddDbContextConnector();

            services.AddScoped<Interfaces.IUnitOfWork, Implementations.UnitOfWork>();
            services.AddTransient<Interfaces.IUserRepository,
                Implementations.UserRepository>();

            return services;
        }
    }
}
