using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.UsuarioDto
{
    public class AtualizarUsuarioDto
    {
        [StringLength(20)]
        public string? Documento { get; set; }

        [StringLength(150)]
        public string? EmpresaInstituicao { get; set; }

        [StringLength(100)]
        public string? Cargo { get; set; }

        [StringLength(100)]
        public string? SetorAtuacao { get; set; }

        [StringLength(200)]
        public string? WebsiteEmpresa { get; set; }

        public bool? ConsentiuEntrarGrupoWhatsApp { get; set; }

        public bool? AutorizaUsoImagem { get; set; }

        public bool? DesejaReceberComunicados { get; set; }
    }
}