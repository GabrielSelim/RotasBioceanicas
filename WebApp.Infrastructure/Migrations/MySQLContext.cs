using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entity;
using WebApp.Domain.Entity.Logas;

namespace WebApp.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext()
        {

        }

        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options){}

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Publicacao> Publicacaoes { get; set; }
        public DbSet<Bannners> Banners { get; set; }

        //Logs
        public DbSet<LogEntry> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica todas as configurações de mapeamento encontradas no assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MySQLContext).Assembly);
        }
    }
}