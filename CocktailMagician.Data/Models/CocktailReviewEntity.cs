using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Models
{
    public class CocktailReviewEntity
    {
        public int Id { get; set; }
        public string UserEntityId { get; set; }
        public int CocktailEntityId { get; set; }
        public CocktailEntity Cocktail { get; set; }
        public UserEntity User { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
