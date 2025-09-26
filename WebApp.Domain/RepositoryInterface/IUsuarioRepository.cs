using WebApp.Domain.Entity;
using WebApp.Domain.Generic;
using WebApp.Repository.Generic;

namespace WebApp.Domain.RepositoryInterface
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario ValidacaoCredencial(Usuario usuario);

        Usuario ValidacaoCredencial(string usuarioNome);

        Usuario AtualizarInfoUsuario(Usuario usuario);

        bool RevokeToken(string usuarioNome);
    }
}