using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.Banner
{
    public class CriarBannerDbo
    {
        [Required]
        [StringLength(500)]
        public required string ImagemUrl { get; set; }

        [StringLength(100)]
        public string? Titulo { get; set; }

        [StringLength(250)]
        public string? Subtitulo { get; set; }

        [StringLength(500)]
        public string? LinkUrl { get; set; }

        [Required]
        public int Ordem { get; set; }

        public bool Ativo { get; set; } = true;
    }
}