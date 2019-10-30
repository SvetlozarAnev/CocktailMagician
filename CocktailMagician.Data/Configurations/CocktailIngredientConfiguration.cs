using CocktailMagician.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailMagician.Data.Configurations
{
    internal class CocktailIngredientConfiguration : IEntityTypeConfiguration<CocktailIngredientEntity>
    {
        public void Configure(EntityTypeBuilder<CocktailIngredientEntity> builder)
        {
            builder
                .HasKey(x => new { x.IngredientEntityId, x.CocktailEntityId });
        }
    }
}
