using System.ComponentModel.DataAnnotations.Schema;
using WebApp.Domain.Entity.Base;

namespace WebApp.Domain.Entity.Logas
{
    [Table("log_entries")]

    public class LogEntry : BaseEntity
    {
        public DateTime DataHora { get; set; }
        public string Nivel { get; set; } // Ex: Information, Warning, Error
        public string Mensagem { get; set; }
        public long UserId { get; set; } // ID do usuário que gerou o log
        public string NomeUsuario { get; set; } // Nome do usuário que gerou o log
        public string? Detalhes { get; set; }
        public string? Origem { get; set; }
    }
}