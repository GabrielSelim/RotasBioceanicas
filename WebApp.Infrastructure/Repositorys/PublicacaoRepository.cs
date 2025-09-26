using WebApp.Domain.Entity;
using WebApp.Domain.RepositoryInterface;
using WebApp.Infrastructure.Repositorys.Generic;
using WebApp.Model.Context;

namespace WebApp.Infrastructure.Repositorys
{
    public class PublicacaoRepository : GenericRepositoryBase<Publicacao>, IPublicacaoRepository
    {
        private readonly MySQLContext _context;
        public PublicacaoRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

    }
}