using WebApp.Application.Dto;

namespace WebApp.Bussines
{
    public interface ILoginBussines
    {
        TokenDbo ValidarCredenciais(UsuarioDbo usuario);

        TokenDbo ValidarCredenciais(TokenDbo token);

        bool RevokeToken(string usuarioNome);
    }
}