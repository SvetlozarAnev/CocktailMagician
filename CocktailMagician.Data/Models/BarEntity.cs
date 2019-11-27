using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Models
{
    public class BarEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(220)]
        public string Address { get; set; }
        public double? Rating { get; set; }
        [Required]
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable <BarCocktailEntity> BarCocktails { get; set; }
        public IEnumerable<BarReviewEntity> BarReviews { get; set; }
    }
}
