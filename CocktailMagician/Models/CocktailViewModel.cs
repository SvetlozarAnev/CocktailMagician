using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Models
{
    public class CocktailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Recipe { get; set; }
        public double? Rating { get; set; }
        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
    }
}
