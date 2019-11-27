using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Data.Models
{
    public class BarReviewEntity
    {
        public int Id { get; set; }
        [Required]
        public string UserEntityId { get; set; }
        [Required]
        public int BarEntityId { get; set; }
        public BarEntity Bar { get; set; }
        public UserEntity User { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [MaxLength(1000)]
        public string Review { get; set; }
    }
}
