using WebApp.Domain.Entity;
using WebApp.Domain.RepositoryInterface;
using WebApp.Infrastructure.Repositorys.Generic;
using WebApp.Model.Context;

namespace WebApp.Infrastructure.Repositorys
{
    public class BannerRepository : GenericRepositoryBase<Banner>, IBannerRepository
    {
        private readonly MySQLContext _context;

        public BannerRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }
    }
}