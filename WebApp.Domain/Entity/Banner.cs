using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Domain.Entity.Base;

namespace WebApp.Domain.Entity
{
    [Table("banners")]
    public class Banner : BaseEntity
    {
        [Column("image_url")]
        [Required(ErrorMessage = "A URL da imagem é obrigatória.")]
        [StringLength(500)]
        public string ImagemUrl { get; set; }

        [Column("title")]
        [StringLength(100)]
        public string? Titulo { get; set; }

        [Column("subtitle")]
        [StringLength(250)]
        public string? Subtitulo { get; set; }

        [Column("link_url")]
        [StringLength(500)]
        public string? LinkUrl { get; set; }

        [Column("display_order")]
        [Required]
        public int Ordem { get; set; } = 0;

        [Column("is_active")]
        [Required]
        public bool Ativo { get; set; } = true;

        [Column("created_at")]
        public DateTime CriadoEm { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? ModificadoEm { get; set; }
    }
}