using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Models
{
    public class CocktailEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Recipe { get; set; }
        public double? Rating { get; set; }
        [Required]
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<BarCocktailEntity> BarCocktails { get; set; }
        public IEnumerable<CocktailIngredientEntity> CocktailIngredients { get; set; }
        public IEnumerable<CocktailReviewEntity> CocktailReviews { get; set; }
    }
}
