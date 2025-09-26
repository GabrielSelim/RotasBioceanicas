using WebApp.Domain.Entity;
using WebApp.Domain.Generic;

namespace WebApp.Domain.RepositoryInterface
{
    public interface IPublicacaoRepository : IRepositoryBase<Publicacao>
    {
        Task<List<Publicacao>> ListarPublicadasAsync();
        Task<List<Publicacao>> ListarPorAutorAsync(int autorId);
        Task<Publicacao?> ObterPorTituloAsync(string titulo);
        Task<bool> AlterarStatusPublicacaoAsync(long id, bool publicado);
    }
}