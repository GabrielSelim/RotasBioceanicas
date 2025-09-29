using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.Publicacao;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Publicacaoes
{
    public class ConverterRetornoPublicacao : IParser<PublicacaoRetornoDbo, Publicacao>, IParser<Publicacao, PublicacaoRetornoDbo>
    {
        public Publicacao Parse(PublicacaoRetornoDbo origem)
        {
            if (origem == null) return null;

            return new Publicacao
            {
                Id = origem.Id,
                Titulo = origem.Titulo,
                Conteudo = origem.Conteudo,
                ImagemUrl = origem.ImagemUrl,
                Publicado = origem.Publicado,
                DataPublicacao = origem.DataPublicacao,
                AutorId = origem.AutorId
            };
        }

        public PublicacaoRetornoDbo Parse(Publicacao origem)
        {
            if (origem == null) return null;

            return new PublicacaoRetornoDbo
            {
                Id = origem.Id,
                Titulo = origem.Titulo,
                Conteudo = origem.Conteudo,
                ImagemUrl = origem.ImagemUrl,
                Publicado = origem.Publicado,
                DataPublicacao = origem.DataPublicacao,
                AutorId = origem.AutorId,
                AutorNome = origem.Autor?.NomeCompleto
            };
        }

        public List<Publicacao> ParseList(List<PublicacaoRetornoDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<PublicacaoRetornoDbo> ParseList(List<Publicacao> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}
