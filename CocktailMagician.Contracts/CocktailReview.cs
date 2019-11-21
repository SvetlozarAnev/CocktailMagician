using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Contracts
{
    public class CocktailReview
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Cocktail Cocktail { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [MaxLength(1000)]
        public string Review { get; set; }
    }
}
