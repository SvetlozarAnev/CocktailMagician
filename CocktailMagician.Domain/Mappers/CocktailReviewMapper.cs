using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;

namespace CocktailMagician.Domain.Mappers
{
    public static class CocktailReviewMapper
    {
        public static CocktailReview ToContract(this CocktailReviewEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new CocktailReview
            {
                Id = entity.Id,
                UserEntityId = entity.UserEntityId,
                CocktailEntityId = entity.CocktailEntityId,
                Rating = entity.Rating,
                Review = entity.Review
            };
        }
    }
}
