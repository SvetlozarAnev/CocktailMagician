using CocktailMagician.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CocktailMagician.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserEntity>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> AppUsers { get; set; }
        public DbSet<BarEntity> Bars { get; set; }
        public DbSet<BarCocktailEntity> BarCocktails { get; set; }
        public DbSet<CocktailEntity> Cocktails { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BarCocktailEntity>()
                .HasKey(x => new { x.BarEntityId, x.CocktailEntityId });
            
            base.OnModelCreating(builder);
        }

        
    }
}
