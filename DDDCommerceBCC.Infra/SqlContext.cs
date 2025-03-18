using Microsoft.EntityFrameworkCore;
using DDDCommerceBCC.Domain;

namespace DDDCommerceBCC.Infra
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.LojaOrigem).IsRequired();
                entity.Property(e => e.Data).IsRequired();
            });
        }
    }
}
