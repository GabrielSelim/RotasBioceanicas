using WebApp.Domain.Entity;
using WebApp.Domain.Generic;

namespace WebApp.Domain.RepositoryInterface
{
    public interface IBannerRepository : IRepositoryBase<Bannners>
    {
        Task<List<Bannners>> ListarAtivosOrdenadosAsync();
        Task<Bannners?> ObterPorOrdemAsync(int ordem);
        Task<bool> AtivarOuDesativarAsync(long id, bool ativo);
    }
}