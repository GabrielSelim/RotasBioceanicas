using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Domain.Entity.Base
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
