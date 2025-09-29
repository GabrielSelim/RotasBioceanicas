using WebApp.Domain.Entity.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Domain.Entity
{
    [Table("publicacoes")]
    public class Publicacao : BaseEntity
    {
        [Column("title")]
        [Required(ErrorMessage = "O título é obrigatório.")]
        [StringLength(200)]
        public string Titulo { get; set; }

        [Column("content")]
        [Required(ErrorMessage = "O conteúdo é obrigatório.")]
        public string Conteudo { get; set; }

        [Column("image_url")]
        [StringLength(500)]
        public string? ImagemUrl { get; set; }

        [Column("is_published")]
        [Required]
        public bool Publicado { get; set; } = false;

        [Column("published_at")]
        [Required]
        public DateTime DataPublicacao { get; set; } = DateTime.UtcNow;

        [Column("author_id")]
        public int AutorId { get; set; }

        [ForeignKey("AutorId")]
        public virtual Usuario Autor { get; set; }
    }
}