using CocktailMagician.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailMagician.Data.Configurations
{
    internal class BarConfiguration : IEntityTypeConfiguration<BarEntity>
    {
        public void Configure(EntityTypeBuilder<BarEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired();
                    

        }

    }
}
