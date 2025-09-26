using WebApp.Application.Dto.Usuario;

namespace WebApp.Application.BusinessInterface
{
    public interface IUsuarioBusiness
    {
        void Criar(CriarUsuarioDbo usuario);
    }
}