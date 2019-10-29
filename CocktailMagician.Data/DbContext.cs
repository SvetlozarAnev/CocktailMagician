using CocktailMagician.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CocktailMagician.Data
{
    public class DbContext : IdentityDbContext<UserEntity>
    {
        public DbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<UserEntity> AppUsers { get; set; }
        public DbSet<BarEntity> Bars { get; set; }
        public DbSet<CocktailEntity> Cocktails { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }
        public DbSet<BarCocktailEntity> BarCocktails { get; set; }
        public DbSet<CocktailIngredientEntity> CocktaiIngredients { get; set; }
        public DbSet<BarReviewEntity> BarReviews { get; set; }
        public DbSet<CocktailReviewEntity> CocktailReviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<BarCocktailEntity>()
                .HasKey(x => new { x.BarEntityId, x.CocktailEntityId });

            builder.Entity<CocktailIngredientEntity>()
               .HasKey(x => new { x.IngredientEntityId, x.CocktailEntityId });

            //builder.Entity<BarReviewEntity>()
            //    .HasOne(x => x.User)
            //    .WithMany(x => x.BarReviews)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<BarReviewEntity>()
            //    .HasOne(x => x.Bar)
            //    .WithMany(x => x.BarReviews)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<CocktailReviewEntity>()
            //    .HasOne(x => x.User)
            //    .WithMany(x => x.CocktailReviews)
            //    .OnDelete(DeleteBehavior.Restrict);

            //builder.Entity<CocktailReviewEntity>()
            //    .HasOne(x => x.Cocktail)
            //    .WithMany(x=>x.CocktailReviews)
            //    .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }


    }
}
