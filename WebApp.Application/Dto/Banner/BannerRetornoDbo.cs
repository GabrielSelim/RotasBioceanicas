using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.Banner
{
    public class BannerRetornoDbo
    {
        public long Id { get; set; }
        public string ImagemUrl { get; set; }
        public string? Titulo { get; set; }
        public string? Subtitulo { get; set; }
        public string? LinkUrl { get; set; }
        public int Ordem { get; set; }
        public bool Ativo { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? ModificadoEm { get; set; }
    }
}