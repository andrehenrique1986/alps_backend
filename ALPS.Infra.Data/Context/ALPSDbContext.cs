using ALPS.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ALPS.Infra.Data.Context
{
    public class ALPSDbContext : DbContext
    {
        public ALPSDbContext(DbContextOptions<ALPSDbContext> options) : base(options)
        {
        }
        
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica automaticamente o UsuarioConfiguration e quaisquer outros mapeamentos futuros
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ALPSDbContext).Assembly);
        }
    }
}
