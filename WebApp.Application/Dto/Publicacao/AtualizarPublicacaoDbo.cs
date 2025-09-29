using System.ComponentModel.DataAnnotations;

namespace WebApp.Application.Dto.Publicacao
{
    public class AtualizarPublicacaoDbo
    {
        [StringLength(200)]
        public string? Titulo { get; set; }

        public string? Conteudo { get; set; }

        [StringLength(500)]
        public string? ImagemUrl { get; set; }

        public bool? Publicado { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public int? AutorId { get; set; }
    }
}