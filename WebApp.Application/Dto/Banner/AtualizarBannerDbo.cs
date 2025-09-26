using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.Banner
{
    public class AtualizarBannerDbo
    {
        [StringLength(500)]
        public string? ImagemUrl { get; set; }

        [StringLength(100)]
        public string? Titulo { get; set; }

        [StringLength(250)]
        public string? Subtitulo { get; set; }

        [StringLength(500)]
        public string? LinkUrl { get; set; }

        public int? Ordem { get; set; }

        public bool? Ativo { get; set; }
    }
}