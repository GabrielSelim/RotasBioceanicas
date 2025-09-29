using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.UsuarioDto;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Usuario
{
    public class ConverterAtualizarUsuario : IParser<AtualizarUsuarioDto, CadastroUsuario>, IParser<CadastroUsuario, AtualizarUsuarioDto>
    {
        public CadastroUsuario Parse(AtualizarUsuarioDto origem)
        {
            if (origem == null) return null;

            return new CadastroUsuario
            {
                Documento = origem.Documento,
                EmpresaInstituicao = origem.EmpresaInstituicao,
                Cargo = origem.Cargo,
                SetorAtuacao = origem.SetorAtuacao,
                WebsiteEmpresa = origem.WebsiteEmpresa,
                ConsentiuEntrarGrupoWhatsApp = origem.ConsentiuEntrarGrupoWhatsApp ?? false,
                AutorizaUsoImagem = origem.AutorizaUsoImagem ?? false,
                DesejaReceberComunicados = origem.DesejaReceberComunicados ?? false
            };
        }

        public AtualizarUsuarioDto Parse(CadastroUsuario origem)
        {
            if (origem == null) return null;

            return new AtualizarUsuarioDto
            {
                Documento = origem.Documento,
                EmpresaInstituicao = origem.EmpresaInstituicao,
                Cargo = origem.Cargo,
                SetorAtuacao = origem.SetorAtuacao,
                WebsiteEmpresa = origem.WebsiteEmpresa,
                ConsentiuEntrarGrupoWhatsApp = origem.ConsentiuEntrarGrupoWhatsApp,
                AutorizaUsoImagem = origem.AutorizaUsoImagem,
                DesejaReceberComunicados = origem.DesejaReceberComunicados
            };
        }

        public List<CadastroUsuario> ParseList(List<AtualizarUsuarioDto> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<AtualizarUsuarioDto> ParseList(List<CadastroUsuario> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}