using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Contracts
{
    public class BarCreateRequest
    {
        [Required(ErrorMessage = "You must enter a valid name")]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(220)]
        public string Address { get; set; }
        public bool IsHidden { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Choose at least one cocktail for the bar menu!")]
        public List<int> Cocktails { get; set; }
    }
}
