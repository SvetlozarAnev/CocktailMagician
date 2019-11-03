using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class BarReview
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Bar Bar { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
