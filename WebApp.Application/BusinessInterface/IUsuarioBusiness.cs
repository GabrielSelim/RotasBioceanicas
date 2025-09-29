using WebApp.Application.Dto.UsuarioDto;

namespace WebApp.Application.BusinessInterface
{
    public interface IUsuarioBusiness
    {
        Task Criar(CriarUsuarioDbo usuario);

        Task Atualizar(long id, AtualizarUsuarioDto usuario);
    }
}