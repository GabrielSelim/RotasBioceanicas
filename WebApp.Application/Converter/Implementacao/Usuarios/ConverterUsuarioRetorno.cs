using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.UsuarioDto;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Usuario
{
    public class ConverterUsuarioRetorno : IParser<UsuarioRetornoDbo, CadastroUsuario>, IParser<CadastroUsuario, UsuarioRetornoDbo>
    {
        public UsuarioRetornoDbo Parse(CadastroUsuario origem)
        {
            if (origem == null) return null;

            return new UsuarioRetornoDbo
            {
                NomeCompleto = origem.NomeCompleto,
                Email = origem.Email,
                Documento = origem.Documento,
                Pais = origem.Pais,
                Cidade = origem.Cidade,
                Estado = origem.Estado,
                DDI = origem.DDI,
                TelefoneNumero = origem.TelefoneNumero,
                EmpresaInstituicao = origem.EmpresaInstituicao,
                Cargo = origem.Cargo,
                SetorAtuacao = origem.SetorAtuacao,
                WebsiteEmpresa = origem.WebsiteEmpresa,
                Role = origem.Role,
                TermosAceitosEm = origem.TermosAceitosEm,
                ConsentiuEntrarGrupoWhatsApp = origem.ConsentiuEntrarGrupoWhatsApp,
                AutorizaUsoImagem = origem.AutorizaUsoImagem,
                DesejaReceberComunicados = origem.DesejaReceberComunicados
            };
        }

        public CadastroUsuario Parse(UsuarioRetornoDbo origem)
        {
            if (origem == null) return null;

            return new CadastroUsuario
            {
                NomeCompleto = origem.NomeCompleto,
                Email = origem.Email,
                Documento = origem.Documento,
                Pais = origem.Pais,
                Cidade = origem.Cidade,
                Estado = origem.Estado,
                DDI = origem.DDI,
                TelefoneNumero = origem.TelefoneNumero,
                EmpresaInstituicao = origem.EmpresaInstituicao,
                Cargo = origem.Cargo,
                SetorAtuacao = origem.SetorAtuacao,
                WebsiteEmpresa = origem.WebsiteEmpresa,
                Role = origem.Role,
                TermosAceitosEm = origem.TermosAceitosEm,
                ConsentiuEntrarGrupoWhatsApp = origem.ConsentiuEntrarGrupoWhatsApp,
                AutorizaUsoImagem = origem.AutorizaUsoImagem,
                DesejaReceberComunicados = origem.DesejaReceberComunicados
            };
        }

        public List<UsuarioRetornoDbo> ParseList(List<CadastroUsuario> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<CadastroUsuario> ParseList(List<UsuarioRetornoDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}