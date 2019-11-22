using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class CocktailCreateRequest
    {
        [Required(ErrorMessage = "You must enter a valid name")]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(1000)]
        public string Recipe { get; set; }
        public bool IsHidden { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        [Required (ErrorMessage ="Choose at least one ingredient!")]
        public List<int> Ingredients { get; set; }
    }
}
