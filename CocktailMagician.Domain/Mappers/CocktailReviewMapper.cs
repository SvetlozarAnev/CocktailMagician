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
                User = entity.User.ToContract(),
                Cocktail = entity.Cocktail.ToContract(),
                Rating = entity.Rating,
                Review = entity.Review
            };

        }
        public static CocktailReviewEntity ToEntity(this CocktailReview contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new CocktailReviewEntity
            {
                UserEntityId = contract.User?.Id,
                CocktailEntityId = contract.Cocktail?.Id??0,
                Rating = contract.Rating,
                Review = contract.Review
            };
        }
    }
}
