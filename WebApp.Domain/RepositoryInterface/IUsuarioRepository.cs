using WebApp.Domain.Entity;
using WebApp.Domain.Generic;

namespace WebApp.Domain.RepositoryInterface
{
    public interface IUsuarioRepository : IRepositoryBase<CadastroUsuario>
    {
        CadastroUsuario ValidacaoCredencial(string email, string senha);

        CadastroUsuario ObterPorEmail(string email);

        bool RevokeToken(string email);
    }
}