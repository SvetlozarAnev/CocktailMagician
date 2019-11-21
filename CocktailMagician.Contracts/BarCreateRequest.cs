using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CocktailMagician.Contracts
{
    public class BarCreateRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool IsHidden { get; set; }
        public IFormFile Image { get; set; }
        public string ImagePath { get; set; }
        public List<int> Cocktails { get; set; }
    }
}
