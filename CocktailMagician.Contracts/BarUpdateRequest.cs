using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Contracts
{
    public class BarUpdateRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a valid name")]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please add cocktails for the bar menu.")]
        public List<int> CocktailIds { get; set; }
    }
}
