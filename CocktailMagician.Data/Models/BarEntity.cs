using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Models
{
    public class BarEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public IEnumerable <BarCocktailEntity> BarCocktails { get; set; }
        public IEnumerable<BarReviewEntity> BarReviews { get; set; }

    }
}
