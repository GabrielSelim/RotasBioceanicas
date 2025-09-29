using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.UsuarioDto
{
    public class CriarUsuarioDbo
    {
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public required string NomeCompleto { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public required string Email { get; set; }

        [Required]
        [StringLength(100)]
        public required string Pais { get; set; }

        [Required]
        [StringLength(150)]
        public required string Cidade { get; set; }

        [Required]
        [StringLength(150)]
        public required string Estado { get; set; }

        [Required]
        [StringLength(5)]
        public required string DDI { get; set; }

        [Required]
        [StringLength(20)]
        public required string TelefoneNumero { get; set; }

        [Required]
        public required string Senha { get; set; }

        [Required]
        public required DateTime TermosAceitosEm { get; set; }
    }
}