using Microsoft.Extensions.DependencyInjection;
using WebApp.Domain.Generic;
using WebApp.Domain.RepositoryInterface;
using WebApp.Domain.RepositoryInterface.Logas;
using WebApp.Infrastructure.Repositorys;
using WebApp.Infrastructure.Repositorys.Generic;
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

            services.AddScoped<IBannerRepository, BannerRepository>();
            services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();

            // Registro genérico
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IRepositoryBase<>), typeof(GenericRepositoryBase<>));


            return services;
        }
    }
}