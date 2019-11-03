using CocktailMagician.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CocktailMagician.Data.Configurations
{
    internal class BarReviewConfiguration : IEntityTypeConfiguration<BarReviewEntity>
    {
        public void Configure(EntityTypeBuilder<BarReviewEntity> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.BarReviews)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Bar)
                .WithMany(x => x.BarReviews)
                .OnDelete(DeleteBehavior.Restrict);

            
        }
    }
}
