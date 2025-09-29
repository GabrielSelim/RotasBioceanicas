using WebApp.Application.Converter.Contrato;
using WebApp.Application.Dto.Banner;
using WebApp.Application.Hypermedia;
using WebApp.Domain.Entity;

namespace WebApp.Application.Converter.Implementacao.Banners
{
    public class ConverterRetornoBanner : IParser<BannerRetornoDbo, Bannners>, IParser<Bannners, BannerRetornoDbo>
    {
        public Bannners Parse(BannerRetornoDbo origem)
        {
            if (origem == null) return null;

            return new Bannners
            {
                Id = origem.Id,
                ImagemUrl = origem.ImagemUrl ?? string.Empty,
                Titulo = origem.Titulo,
                Subtitulo = origem.Subtitulo,
                LinkUrl = origem.LinkUrl,
                Ordem = origem.Ordem,
                Ativo = origem.Ativo,
                CriadoEm = origem.CriadoEm,
                ModificadoEm = origem.ModificadoEm
            };
        }

        public BannerRetornoDbo Parse(Bannners origem)
        {
            if (origem == null) return null;

            return new BannerRetornoDbo
            {
                Id = origem.Id,
                ImagemUrl = origem.ImagemUrl,
                Titulo = origem.Titulo,
                Subtitulo = origem.Subtitulo,
                LinkUrl = origem.LinkUrl,
                Ordem = origem.Ordem,
                Ativo = origem.Ativo,
                CriadoEm = origem.CriadoEm,
                ModificadoEm = origem.ModificadoEm
            };
        }

        public List<Bannners> ParseList(List<BannerRetornoDbo> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }

        public List<BannerRetornoDbo> ParseList(List<Bannners> origem)
        {
            if (origem == null) return null;
            return origem.Select(Parse).ToList();
        }
    }
}
