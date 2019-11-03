using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Models
{
    public class BarReviewViewModel
    {
        public int Id { get; set; }
        public string UserEntityId { get; set; }
        public int BarEntityId { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }
    }
}
