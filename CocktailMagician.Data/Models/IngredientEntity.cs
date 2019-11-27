using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Models
{
    public class IngredientEntity
    {
        public int Id { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public int TimesUsed { get; set; }
        public IEnumerable<CocktailIngredientEntity> CocktailIngredients { get; set; }
    }
}
