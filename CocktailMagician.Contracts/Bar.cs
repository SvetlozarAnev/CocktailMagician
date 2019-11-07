using System.Collections.Generic;

namespace CocktailMagician.Contracts
{
    public class Bar
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Cocktail> Cocktails { get; set; }
    }
}
