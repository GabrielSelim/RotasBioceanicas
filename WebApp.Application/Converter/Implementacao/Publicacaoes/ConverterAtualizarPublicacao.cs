using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.Publicacao;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Publicacaoes
{
    public class ConverterAtualizarPublicacao : IParser<AtualizarPublicacaoDbo, Publicacao>, IParser<Publicacao, AtualizarPublicacaoDbo>
    {
        public Publicacao Parse(AtualizarPublicacaoDbo origem)
        {
            if (origem == null) return null;

            return new Publicacao
            {
                Titulo = origem.Titulo ?? string.Empty,
                Conteudo = origem.Conteudo ?? string.Empty,
                ImagemUrl = origem.ImagemUrl,
                Publicado = origem.Publicado ?? false,
                DataPublicacao = origem.DataPublicacao ?? DateTime.UtcNow,
                AutorId = origem.AutorId ?? 0
            };
        }

        public AtualizarPublicacaoDbo Parse(Publicacao origem)
        {
            if (origem == null) return null;

            return new AtualizarPublicacaoDbo
            {
                Titulo = origem.Titulo,
                Conteudo = origem.Conteudo,
                ImagemUrl = origem.ImagemUrl,
                Publicado = origem.Publicado,
                DataPublicacao = origem.DataPublicacao,
                AutorId = origem.AutorId
            };
        }

        public List<Publicacao> ParseList(List<AtualizarPublicacaoDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<AtualizarPublicacaoDbo> ParseList(List<Publicacao> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}