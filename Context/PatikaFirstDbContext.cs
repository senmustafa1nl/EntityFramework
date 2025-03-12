using CodeFirstBasic.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstBasic.Context
{
    public class PatikaFirstDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=MSNL;Database=PatikaFirstCodeDb;Trusted_Connection=True;TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<GameEntity> Games => Set<GameEntity>();
        public DbSet<MovieEntity> Movies => Set<MovieEntity>();
    }
}
