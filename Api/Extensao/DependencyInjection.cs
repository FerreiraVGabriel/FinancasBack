using Infra.Interface;
using Infra.Repository;
using Services.Interfaces;
using Services.Services;
using System.Reflection;

namespace Api.Extensao
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            //SERVICES
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITokenService, TokenService>();

            //REPOSITORIES
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
