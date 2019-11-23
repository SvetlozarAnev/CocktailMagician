using System.ComponentModel.DataAnnotations;

namespace CocktailMagician.Contracts
{
    public class Search
    {
        [Required(ErrorMessage = "Required")]
        [MinLength(1)]
        [DataType(DataType.Text)]
        public string Text { get; set; }
    }
}
