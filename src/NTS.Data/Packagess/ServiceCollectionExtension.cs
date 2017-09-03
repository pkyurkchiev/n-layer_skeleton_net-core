namespace NTS.Data.Packagess
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.EntityFrameworkCore;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDbContextConnector(this IServiceCollection services)
        {
            //services.AddDbContext<Context.NTSContext>(options =>
            //    options.UseSqlServer(@"Data Source = localhost; Initial Catalog = MyDW; Persist Security Info = False; User ID = TempUser; Password = Temp123"));
            services.AddScoped<DbContext, Context.NTSContext>();

            return services;
        }
    }
}
