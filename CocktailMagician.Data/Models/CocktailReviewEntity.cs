using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Models
{
    public class CocktailReviewEntity
    {
        public int Id { get; set; }
        [Required]
        public string UserEntityId { get; set; }
        [Required]
        public int CocktailEntityId { get; set; }
        public CocktailEntity Cocktail { get; set; }
        public UserEntity User { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [MaxLength(1000)]
        public string Review { get; set; }
    }
}
