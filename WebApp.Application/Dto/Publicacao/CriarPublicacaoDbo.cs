using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.Publicacao
{
    public class CriarPublicacaoDbo
    {
        [Required]
        [StringLength(200)]
        public required string Titulo { get; set; }

        [Required]
        public required string Conteudo { get; set; }

        [StringLength(500)]
        public string? ImagemUrl { get; set; }

        [Required]
        public int AutorId { get; set; }
    }
}