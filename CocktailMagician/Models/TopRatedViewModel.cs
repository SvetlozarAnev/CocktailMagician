using CocktailMagician.Contracts;
using System.Collections.Generic;

namespace CocktailMagician.Models
{
    public class TopRatedViewModel
    {
        public ICollection<Bar> TopRatedBars { get; set; }
        public ICollection<Cocktail> TopRatedCocktails { get; set; }
    }
}
