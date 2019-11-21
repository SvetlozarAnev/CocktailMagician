using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Contracts
{
    public class Cocktail
    {
        public int Id { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Recipe { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public IEnumerable<Ingredient> Ingredients{ get; set; }
    }
}
