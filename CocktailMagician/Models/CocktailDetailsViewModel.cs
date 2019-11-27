using CocktailMagician.Contracts;
using System.Collections.Generic;

namespace CocktailMagician.Models
{
    public class CocktailDetailsViewModel
    {
        public Cocktail Cocktail { get; set; }
        public IEnumerable<CocktailReview> CocktailReviews { get; set; }
    }
}
