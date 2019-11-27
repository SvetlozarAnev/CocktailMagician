using CocktailMagician.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Models
{
    public class BarDetailsViewModel
    {
        public Bar Bar { get; set; }
        public IEnumerable<BarReview> BarReviews { get; set; }
    }
}
