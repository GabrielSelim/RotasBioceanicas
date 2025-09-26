namespace WebApp.Application.Dto.Usuario
{
    public class UsuarioRetornoDbo
    {
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public string? Documento { get; set; }
        public string Pais { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string DDI { get; set; }
        public string TelefoneNumero { get; set; }
        public string? EmpresaInstituicao { get; set; }
        public string? Cargo { get; set; }
        public string? SetorAtuacao { get; set; }
        public string? WebsiteEmpresa { get; set; }
        public string Role { get; set; }
        public DateTime TermosAceitosEm { get; set; }
        public bool ConsentiuEntrarGrupoWhatsApp { get; set; }
        public bool AutorizaUsoImagem { get; set; }
        public bool DesejaReceberComunicados { get; set; }
    }
}