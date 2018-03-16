using System;
using Core.Data.Repositories;
using Core.Domain.Interfaces.Repositories;
using Core.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<UserService, UserService>();            
        }
    }
}
