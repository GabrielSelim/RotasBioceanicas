using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.Publicacao;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Publicacaoes
{
    public class ConverterCriarPublicacao : IParser<CriarPublicacaoDbo, Publicacao>, IParser<Publicacao, CriarPublicacaoDbo>
    {
        public Publicacao Parse(CriarPublicacaoDbo origem)
        {
            if (origem == null) return null;

            return new Publicacao
            {
                Titulo = origem.Titulo,
                Conteudo = origem.Conteudo,
                ImagemUrl = origem.ImagemUrl,
                AutorId = origem.AutorId,
                Publicado = false,
                DataPublicacao = DateTime.UtcNow
            };
        }

        public CriarPublicacaoDbo Parse(Publicacao origem)
        {
            if (origem == null) return null;

            return new CriarPublicacaoDbo
            {
                Titulo = origem.Titulo,
                Conteudo = origem.Conteudo,
                ImagemUrl = origem.ImagemUrl,
                AutorId = origem.AutorId
            };
        }

        public List<Publicacao> ParseList(List<CriarPublicacaoDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<CriarPublicacaoDbo> ParseList(List<Publicacao> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}