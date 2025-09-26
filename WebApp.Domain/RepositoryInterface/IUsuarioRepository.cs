using WebApp.Domain.Entity;
using WebApp.Domain.Generic;

namespace WebApp.Domain.RepositoryInterface
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ValidacaoCredencial(string email, string senha);

        Usuario ObterPorEmail(string email);

        bool RevokeToken(string email);
    }
}