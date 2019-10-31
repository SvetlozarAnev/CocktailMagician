using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Mappers.Contracts;

namespace CocktailMagician.Domain.Mappers
{
    public class CocktailReviewMapper : IMapper<CocktailReviewEntity, CocktailReview>
    {
        public CocktailReview MapFrom(CocktailReviewEntity entity)
        => new CocktailReview
        {
            Id = entity.Id,
            UserEntityId = entity.UserEntityId,
            CocktailEntityId = entity.CocktailEntityId,
            Rating = entity.Rating,
            Review = entity.Review,
        };
    }
}
