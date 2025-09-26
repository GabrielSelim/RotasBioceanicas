using System.Data.Entity;
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

        public async Task<List<Banner>> ListarAtivosOrdenadosAsync()
        {
            return await _context.Set<Banner>()
                .Where(b => b.Ativo)
                .OrderByDescending(b => b.CriadoEm)
                .ToListAsync();
        }

        public async Task<Banner?> ObterPorOrdemAsync(int ordem)
        {
            return await _context.Set<Banner>()
                .FirstOrDefaultAsync(b => b.Ordem == ordem);
        }

        public async Task<bool> AtivarOuDesativarAsync(long id, bool ativo)
        {
            var banner = await _context.Set<Banner>().FirstOrDefaultAsync(b => b.Id == id);
            if (banner == null) return false;
            banner.Ativo = ativo;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}