using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Models
{
    public class IngredientEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TimesUsed { get; set; }
        public IEnumerable<CocktailIngredientEntity> CocktailIngredients { get; set; }
    }
}
