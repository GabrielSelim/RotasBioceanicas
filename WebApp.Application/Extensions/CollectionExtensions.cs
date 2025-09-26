using WebApp.Bussines.Implementacoes;
using WebApp.Bussines;
using WebApp.Domain.ServiceInterface;
using WebApp.Domain.Service;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Infrastructure.Services.Validation;
using WebApp.Domain.Entity;
using WebApp.Application.BusinessInterface;
using WebApp.Application.Business;
using WebApp.Domain.Entity.Logas;
using WebApp.Domain.Service.Logas;


namespace WebApp.Application.Extensions
{
    public static class CollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenService, TokenService>();
            services.AddTransient<IEntityValidationService<Usuario>, UsuarioValidationService>();

            //Logs
            services.AddTransient<IEntityValidationService<LogEntry>, LogsValidationService>();

            return services;
        }

        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            //Login
            services.AddScoped<ILoginBussines, LoginBussinesImplementation>();
            services.AddScoped<IUsuarioBusiness, UsuarioBusinessImplementacao>();

            return services;
        }
    }
}