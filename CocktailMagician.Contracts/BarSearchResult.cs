using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class BarSearchResult
    {
        public List<Bar> Input { get; set; }
    }
}