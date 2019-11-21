using CocktailMagician.Data.Configurations;
using CocktailMagician.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;

namespace CocktailMagician.Data
{
    public class AppDBContext : IdentityDbContext<UserEntity>
    {
        public AppDBContext(DbContextOptions/*<DbContext>*/ options)
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

        private void LoadJsonInDb(ModelBuilder builder)
        {
            try
            {
                var usersAsJson =
                     File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\users.json");

                var rolesAsJson =
                     File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\roles.json");

                var barsAsJson =
                    File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\bars.json");

                var cocktailsAsJson =
                    File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\cocktails.json");

                var ingredientsAsJson =
                    File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\ingredients.json");

                var userRolesAsJson =
                     File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\userRoles.json");

                var barCocktailsAsJson =
                    File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\barCocktails.json");

                var cocktailIngredientsAsJson =
                    File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\cocktailIngredients.json");
                var barReviewsAsJson =
                     File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\barReviews.json");
                var cocktailReviewsAsJson =
                    File.ReadAllText(@"..\CocktailMagician.Data\JsonSeed\cocktailReviews.json");

                var users =
                    JsonConvert.DeserializeObject<UserEntity[]>(usersAsJson);

                var roles =
                    JsonConvert.DeserializeObject<IdentityRole[]>(rolesAsJson);

                var bars =
                    JsonConvert.DeserializeObject<BarEntity[]>(barsAsJson);

                var cocktails =
                    JsonConvert.DeserializeObject<CocktailEntity[]>(cocktailsAsJson);

                var ingredients =
                    JsonConvert.DeserializeObject<IngredientEntity[]>(ingredientsAsJson);

                var userRoles = JsonConvert.DeserializeObject<IdentityUserRole<string>[]>(userRolesAsJson);

                var barCocktails =
                    JsonConvert.DeserializeObject<BarCocktailEntity[]>(barCocktailsAsJson);

                var cocktailIngredients =
                    JsonConvert.DeserializeObject<CocktailIngredientEntity[]>(cocktailIngredientsAsJson);
                var barReviews =
                    JsonConvert.DeserializeObject<BarReviewEntity[]>(barReviewsAsJson);
                var cocktailReviews =
                    JsonConvert.DeserializeObject<CocktailReviewEntity[]>(cocktailReviewsAsJson);

                builder.Entity<UserEntity>()
                    .HasData(users);
                builder.Entity<IdentityRole>()
                    .HasData(roles);
                builder.Entity<BarEntity>()
                    .HasData(bars);
                builder.Entity<CocktailEntity>()
                    .HasData(cocktails);
                builder.Entity<IngredientEntity>()
                    .HasData(ingredients);
                builder.Entity<IdentityUserRole<string>>()
                    .HasData(userRoles);
                builder.Entity<BarCocktailEntity>()
                    .HasData(barCocktails);
                builder.Entity<CocktailIngredientEntity>()
                    .HasData(cocktailIngredients);
                builder.Entity<BarReviewEntity>()
                    .HasData(barReviews);
                builder.Entity<CocktailReviewEntity>()
                    .HasData(cocktailReviews);
            }
            catch (Exception)
            {

                return;
            }
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            LoadJsonInDb(builder);


            builder.ApplyConfiguration(new BarReviewConfiguration());
            builder.ApplyConfiguration(new CocktailReviewConfiguration());
            builder.ApplyConfiguration(new BarCocktailConfiguration());
            builder.ApplyConfiguration(new CocktailIngredientConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
