using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Contracts
{
    public class Bar
    {
        public int Id { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(220)]
        public string Address { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public IEnumerable<Cocktail> Cocktails { get; set; }
    }
}
