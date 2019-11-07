﻿using System.Collections.Generic;

namespace CocktailMagician.Contracts
{
    public class Cocktail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<Ingredient> Ingredients{ get; set; }
    }
}
