using CocktailMagician.Contracts;
using CocktailMagician.Contracts.Objects;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Mappers.Contracts;

namespace CocktailMagician.Domain.Mappers
{
    public class BarReviewMapper : IMapper<BarReviewEntity, BarReview>
    {
        public BarReview MapFrom(BarReviewEntity entity)
        => new BarReview
        {
            Id = entity.Id,
            UserEntityId = entity.UserEntityId,
            BarEntityId = entity.BarEntityId,
            Rating = entity.Rating,
            Review = entity.Review
        };
    }
}

