using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class SearchResult
    {
        [Required(ErrorMessage = "Required")]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string Input { get; set; }
    }
}
