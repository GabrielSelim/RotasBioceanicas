using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.Usuario;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao
{
    public class UsuarioConverter : IParser<UsuarioDbo, CadastroUsuario>, IParser<CadastroUsuario, UsuarioDbo>
    {
        public CadastroUsuario Parse(UsuarioDbo origem)
        {
            if (origem == null) return null;

            return new CadastroUsuario
            {
                //NomeUsuario = origem.NomeUsuario,
                Senha = origem.Senha,
                NomeCompleto = origem.NomeCompleto,
                RefreshToken = origem.RefreshToken,
                RefreshTokenTempoExpiracao = origem.RefreshTokenTempoExpiracao
            };
        }

        public UsuarioDbo Parse(CadastroUsuario origem)
        {
            if (origem == null) return null;

            return new UsuarioDbo
            {
                //NomeUsuario = origem.NomeUsuario,
                Senha = origem.Senha,
                NomeCompleto = origem.NomeCompleto,
                RefreshToken = origem.RefreshToken,
                RefreshTokenTempoExpiracao = origem.RefreshTokenTempoExpiracao
            };
        }

        public List<CadastroUsuario> ParseList(List<UsuarioDbo> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }

        public List<UsuarioDbo> ParseList(List<CadastroUsuario> origem)
        {
            if (origem == null) return null;

            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
