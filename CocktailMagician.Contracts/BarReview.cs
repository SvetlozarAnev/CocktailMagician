using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Contracts
{
    public class BarReview
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Bar Bar { get; set; }
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        [MaxLength(1000)]
        public string Review { get; set; }
    }
}