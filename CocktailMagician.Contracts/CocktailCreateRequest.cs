using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class CocktailCreateRequest
    {
        [Required(ErrorMessage = "Choose a name")]
        public string Name { get; set; }
        [Required]
        public string Recipe { get; set; }
        public bool IsHidden { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        [Required (ErrorMessage ="Choose at least one ingredient!")]
        public List<int> Ingredients { get; set; }
    }
}
