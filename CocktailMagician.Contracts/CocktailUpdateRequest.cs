using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class CocktailUpdateRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a valid name")]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        public string Recipe { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please select the needed ingredients")]
        public List<int> IngredientIds { get; set; }
    }
}
