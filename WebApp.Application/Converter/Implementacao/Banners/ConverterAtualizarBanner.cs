using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.Banner;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Banners
{
    public class ConverterAtualizarBanner : IParser<AtualizarBannerDbo, Bannners>, IParser<Bannners, AtualizarBannerDbo>
    {
        public AtualizarBannerDbo Parse(Bannners origem)
        {
            if (origem == null) return null;

            return new AtualizarBannerDbo
            {
                ImagemUrl = origem.ImagemUrl,
                Titulo = origem.Titulo,
                Subtitulo = origem.Subtitulo,
                LinkUrl = origem.LinkUrl,
                Ordem = origem.Ordem,
                Ativo = origem.Ativo
            };
        }

        public Bannners Parse(AtualizarBannerDbo origem)
        {
            if (origem == null) return null;

            return new Bannners
            {
                ImagemUrl = origem.ImagemUrl ?? string.Empty,
                Titulo = origem.Titulo,
                Subtitulo = origem.Subtitulo,
                LinkUrl = origem.LinkUrl,
                Ordem = origem.Ordem ?? 0,
                Ativo = origem.Ativo ?? true,
                CriadoEm = DateTime.UtcNow
            };
        }

        public List<AtualizarBannerDbo> ParseList(List<Bannners> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<Bannners> ParseList(List<AtualizarBannerDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}