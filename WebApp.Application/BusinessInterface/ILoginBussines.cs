using WebApp.Application.Dto;
using WebApp.Application.Dto.Usuario;

namespace WebApp.Bussines
{
    public interface ILoginBussines
    {
       // TokenDbo ValidarCredenciais(LoginUsuarioDbo usuario);

        //TokenDbo ValidarCredenciais(TokenDbo token);

        bool RevokeToken(string usuarioNome);
    }
}