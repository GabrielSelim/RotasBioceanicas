using System.ComponentModel.DataAnnotations;
using WebApp.Domain.Entity;
using WebApp.Domain.ServiceInterface;

namespace WebApp.Domain.Service
{
    public class PublicacaoValidationService : IEntityValidationService<Publicacao>
    {
        public void Validate(Publicacao publicacao)
        {
            if (string.IsNullOrWhiteSpace(publicacao.Titulo))
                throw new ValidationException("O título é obrigatório.");

            if (publicacao.Titulo.Length > 200)
                throw new ValidationException("O título deve ter no máximo 200 caracteres.");

            if (string.IsNullOrWhiteSpace(publicacao.Conteudo))
                throw new ValidationException("O conteúdo é obrigatório.");

            if (!string.IsNullOrWhiteSpace(publicacao.ImagemUrl) && publicacao.ImagemUrl.Length > 500)
                throw new ValidationException("A URL da imagem deve ter no máximo 500 caracteres.");

            if (publicacao.DataPublicacao == default)
                throw new ValidationException("A data de publicação é obrigatória.");

            if (publicacao.AutorId <= 0)
                throw new ValidationException("O autor é obrigatório.");
        }
    }
}