using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.UsuarioDto;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Usuario
{
    public class ConverterCriarUsuario : IParser<CriarUsuarioDbo, CadastroUsuario>, IParser<CadastroUsuario, CriarUsuarioDbo>
    {
        public CadastroUsuario Parse(CriarUsuarioDbo origem)
        {
            if (origem == null) return null;

            return new CadastroUsuario
            {
                NomeCompleto = origem.NomeCompleto,
                Email = origem.Email,
                Pais = origem.Pais,
                Cidade = origem.Cidade,
                Estado = origem.Estado,
                DDI = origem.DDI,
                TelefoneNumero = origem.TelefoneNumero,
                Senha = origem.Senha,
                TermosAceitosEm = origem.TermosAceitosEm
            };
        }

        public CriarUsuarioDbo Parse(CadastroUsuario origem)
        {
            if (origem == null) return null;

            return new CriarUsuarioDbo
            {
                NomeCompleto = origem.NomeCompleto,
                Email = origem.Email,
                Pais = origem.Pais,
                Cidade = origem.Cidade,
                Estado = origem.Cidade,
                DDI = origem.DDI,
                TelefoneNumero = origem.TelefoneNumero,
                Senha = origem.Senha,
                TermosAceitosEm = origem.TermosAceitosEm
            };
        }

        public List<CadastroUsuario> ParseList(List<CriarUsuarioDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<CriarUsuarioDbo> ParseList(List<CadastroUsuario> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}
