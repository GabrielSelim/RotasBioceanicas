using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.UsuarioDto
{
    public class LoginUsuarioDbo
    {
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public required string Email { get; set; }

        [Required]
        public required string Senha { get; set; }
    }
}