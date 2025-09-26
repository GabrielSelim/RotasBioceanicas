using WebApp.Application.Dto.Logas;

namespace WebApp.Application.BusinessInterface.Logas
{
    public interface ILogBusiness
    {
        void Criar(LogEntryDbo logEntry);
    }
}