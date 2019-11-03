using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;


namespace CocktailMagician.Domain.Mappers
{
    public static class BarReviewMapper
    {
        public static BarReview ToContract(this BarReviewEntity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new BarReview
            {
                Id = entity.Id,
                User = entity.User.ToContract(),
                Bar = entity.Bar.ToContract(),
                Rating = entity.Rating,
                Review = entity.Review
            };
        }

    }
}

