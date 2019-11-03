using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Contracts.Objects
{
    public class BarReview
    {
        public int Id { get; set; }
        public string UserEntityId { get; set; }
        public int BarEntityId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
