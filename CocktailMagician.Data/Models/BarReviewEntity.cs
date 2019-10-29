using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Data.Models
{
    public class BarReviewEntity
    {
        public int Id { get; set; }
        public string UserEntityId { get; set; }
        public int BarEntityId { get; set; }
        public BarEntity Bar { get; set; }
        public UserEntity User { get; set; }
        public int Rating { get; set; }
        public string Review { get; set; }

    }
}
