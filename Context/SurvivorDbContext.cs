using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pratik_Survivor_Dependency_Injection.Entities;

namespace Pratik_Survivor_Dependency_Injection.Context
{
    public class SurvivorDbContext : DbContext
    {
        public SurvivorDbContext(DbContextOptions<SurvivorDbContext> options) : base (options)
        {
        }
        //protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        //{
        //    base.ConfigureConventions(configurationBuilder);
        //    OptionsBuilder.usesqlserver("Server=MSNL;Database=SurvivorDb;Trusted_Connection=True;TrustServerCertificate=True");
        //}
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<CompetitorsEntity> Competitors { get; set; }

    }
   
}
