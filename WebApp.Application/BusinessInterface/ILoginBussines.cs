using WebApp.Application.Dto;
using WebApp.Application.Dto.UsuarioDto;

namespace WebApp.Bussines
{
    public interface ILoginBussines
    {
        TokenDbo ValidarCredenciais(LoginUsuarioDbo usuario);

        //TokenDbo ValidarCredenciais(TokenDbo token);

        bool RevokeToken(string usuarioNome);
    }
}