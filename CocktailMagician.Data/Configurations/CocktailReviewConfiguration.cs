using CocktailMagician.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Configurations
{
    internal class CocktailReviewConfiguration : IEntityTypeConfiguration<CocktailReviewEntity>
    {
        public void Configure(EntityTypeBuilder<CocktailReviewEntity> builder)
        {
            builder
                .HasOne(x => x.User)
                .WithMany(x => x.CocktailReviews)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(x => x.Cocktail)
                .WithMany(x => x.CocktailReviews)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}