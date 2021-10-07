using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        // Representação da Model no banco de dados
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Command> Commands { get; set; }

        // Declarando explicitamente a relação entre Platform e Command
        // Não é obrigatório sempre, é feito aqui apenas para garantir que as migrations serão corretas.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Platform>()
                .HasMany(p => p.Commands)
                .WithOne(p => p.Platform!) // Relação com si mesmo (nullable)
                .HasForeignKey(p => p.PlatformId);

            // Relação detalhada entre command e platform
            modelBuilder
                .Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Commands)
                .HasForeignKey(p => p.PlatformId);
        }
    }
}