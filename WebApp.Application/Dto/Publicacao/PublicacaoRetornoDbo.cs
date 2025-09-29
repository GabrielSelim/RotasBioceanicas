using WebApp.Application.Hypermedia;
using WebApp.Application.Hypermedia.Abstract;

namespace WebApp.Application.Dto.Publicacao
{
    public class PublicacaoRetornoDbo : ISupportHyperMedia
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public string? ImagemUrl { get; set; }
        public bool Publicado { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int AutorId { get; set; }
        public string? AutorNome { get; set; }

        public List<HyperMediaLink> Links { get; set; } = new List<HyperMediaLink>();
    }
}