using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Models
{
    public class CocktailEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<BarCocktailEntity> BarCocktails { get; set; }
    }
}
