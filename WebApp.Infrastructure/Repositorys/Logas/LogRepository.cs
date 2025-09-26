using WebApp.Domain.Entity.Logas;
using WebApp.Domain.RepositoryInterface.Logas;
using WebApp.Model.Context;
using WebApp.Repository.Generic;

namespace WebApp.Infrastructure.Repositorys.Logas
{
    public class LogRepository : GenericRepository<LogEntry>, ILogRepository
    {
        public LogRepository(MySQLContext context) : base(context)
        {
        }
    }
}
