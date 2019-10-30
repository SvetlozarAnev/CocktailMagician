using CocktailMagician.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailMagician.Data.Configurations
{
    internal class BarCocktailConfiguration : IEntityTypeConfiguration<BarCocktailEntity>
    {
        public void Configure(EntityTypeBuilder<BarCocktailEntity> builder)
        {
            builder
                 .HasKey(x => new { x.BarEntityId, x.CocktailEntityId });
        }
    }
}
