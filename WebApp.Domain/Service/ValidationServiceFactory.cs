using WebApp.Domain.Entity;
using WebApp.Domain.Entity.Logas;
using WebApp.Domain.Service;
using WebApp.Domain.Service.Logas;
using WebApp.Domain.ServiceInterface;

namespace WebApp.Infrastructure.Services.Validation
{
    public class ValidationServiceFactory
    {
        public static IEntityValidationService<T> GetValidationService<T>()
        {
            if (typeof(T) == typeof(CadastroUsuario))
                return (IEntityValidationService<T>)new UsuarioValidationService();

            if (typeof(T) == typeof(LogEntry))
                return (IEntityValidationService<T>)new LogsValidationService();

            if (typeof(T) == typeof(Bannners))
                return (IEntityValidationService<T>)new BannerValidationService();

            if (typeof(T) == typeof(Publicacao))
                return (IEntityValidationService<T>)new PublicacaoValidationService();

            throw new NotImplementedException($"Serviço de validação não implementado para o tipo {typeof(T).Name}");
        }
    }
}