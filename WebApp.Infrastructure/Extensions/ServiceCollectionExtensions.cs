using Microsoft.Extensions.DependencyInjection;
using WebApp.Domain.RepositoryInterface;
using WebApp.Domain.RepositoryInterface.Logas;
using WebApp.Infrastructure.Repositorys;
using WebApp.Infrastructure.Repositorys.Logas;
using WebApp.Repository.Generic;

namespace WebApp.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            //Logs
            services.AddScoped<ILogRepository, LogRepository>();

            // Registro genérico
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}