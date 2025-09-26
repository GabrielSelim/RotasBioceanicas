using WebApp.Domain.Entity.Base;

namespace WebApp.Domain.Generic
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<T> CriarAsync(T item);

        Task<T> AtualizarAsync(T item);

        Task<List<T>> ObterTodosAsync();

        Task<T> ObterPorIdAsync(long id);

        Task DeletarAsync(long id);

        Task<bool> ExisteAsync(long id);

        Task<List<T>> ObterComPaginacaoAsync(int pageNumber, int pageSize, string sortDirection);

        Task<int> GetCountAsync();
    }
}