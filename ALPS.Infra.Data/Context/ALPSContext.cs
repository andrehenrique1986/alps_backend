using ALPS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ALPS.Infra.Data.Context
{
    public class ALPSContext : DbContext
    {
        public ALPSContext(DbContextOptions<ALPSContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ALPSContext).Assembly);
        }

        public DbSet<Usuario> Usuario { get; set; } 
    }
}
