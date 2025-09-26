using System.ComponentModel.DataAnnotations;
using WebApp.Domain.Entity;
using WebApp.Domain.ServiceInterface;

namespace WebApp.Domain.Service
{
    public class BannerValidationService : IEntityValidationService<Banner>
    {
        public void Validate(Banner banner)
        {
            if (string.IsNullOrWhiteSpace(banner.ImagemUrl))
                throw new ValidationException("A URL da imagem é obrigatória.");

            if (banner.ImagemUrl.Length > 500)
                throw new ValidationException("A URL da imagem deve ter no máximo 500 caracteres.");

            if (!string.IsNullOrWhiteSpace(banner.Titulo) && banner.Titulo.Length > 100)
                throw new ValidationException("O título deve ter no máximo 100 caracteres.");

            if (!string.IsNullOrWhiteSpace(banner.Subtitulo) && banner.Subtitulo.Length > 250)
                throw new ValidationException("O subtítulo deve ter no máximo 250 caracteres.");

            if (!string.IsNullOrWhiteSpace(banner.LinkUrl) && banner.LinkUrl.Length > 500)
                throw new ValidationException("O link deve ter no máximo 500 caracteres.");
        }
    }
}