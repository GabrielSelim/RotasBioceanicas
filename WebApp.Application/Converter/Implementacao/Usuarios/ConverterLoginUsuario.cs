using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.UsuarioDto;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Usuario
{
    public class ConverterLoginUsuario : IParser<LoginUsuarioDbo, CadastroUsuario>, IParser<CadastroUsuario, LoginUsuarioDbo>
    {
        public CadastroUsuario Parse(LoginUsuarioDbo origem)
        {
            if (origem == null) return null;

            return new CadastroUsuario
            {
                Email = origem.Email,
                Senha = origem.Senha
            };
        }

        public LoginUsuarioDbo Parse(CadastroUsuario origem)
        {
            if (origem == null) return null;

            return new LoginUsuarioDbo
            {
                Email = origem.Email,
                Senha = origem.Senha
            };
        }

        public List<CadastroUsuario> ParseList(List<LoginUsuarioDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<LoginUsuarioDbo> ParseList(List<CadastroUsuario> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}