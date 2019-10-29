using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Models
{
    public class BarCocktailEntity
    {
        public int BarEntityId { get; set; }
        public int CocktailEntityId { get; set; }
        public BarEntity BarEntity { get; set; }
        public CocktailEntity CocktailEntity { get; set; }
    }
}
