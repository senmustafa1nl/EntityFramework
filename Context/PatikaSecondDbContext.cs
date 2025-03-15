using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Pratik_CodeFirstRelation.Entities;

namespace Pratik_CodeFirstRelation.Context
{
    public class PatikaSecondDbContext : DbContext 
    {
        public PatikaSecondDbContext(DbContextOptions<PatikaSecondDbContext> options) : base(options) 
        {
    
            
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);
        //    optionsBuilder.UseSqlServer(@"Server=MSNL; Database=PatikaCodeFirstDb2; TrustServerCertificate=True; Trusted_Connection=True;");
        //}
        public DbSet<PostEntity> Posts => Set <PostEntity>();
        public DbSet<UserEntity> Users => Set <UserEntity>();
    }
}
