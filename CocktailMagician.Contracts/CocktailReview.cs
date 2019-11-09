using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class CocktailReview
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Cocktail Cocktail { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
