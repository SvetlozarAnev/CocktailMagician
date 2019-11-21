using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class Ingredient
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You must enter a valid name")]
        [StringLength(70, MinimumLength = 3)]
        public string Name { get; set; }
        public int TimesUsed { get; set; }
    }
}
