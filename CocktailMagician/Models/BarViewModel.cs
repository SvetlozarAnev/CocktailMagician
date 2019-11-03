using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Models
{
    public class BarViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
    }
}
