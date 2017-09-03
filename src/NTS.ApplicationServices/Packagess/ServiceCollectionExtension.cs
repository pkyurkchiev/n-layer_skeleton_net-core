﻿namespace NTS.ApplicationServices.Packagess
{
    using Microsoft.Extensions.DependencyInjection;
    using Repositories.Packagess;

    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInternalServices(this IServiceCollection services)
        {
            services.AddRepositoryConnector();

            services.AddTransient<Interfaces.Users.IUserManagementService,
                Implementations.UserManagementService>();

            return services;
        }
    }
}
