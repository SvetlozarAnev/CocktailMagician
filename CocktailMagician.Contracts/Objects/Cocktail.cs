using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Contracts.Objects
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
    }
}
