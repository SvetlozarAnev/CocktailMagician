﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Contracts
{
    public class BarCreateRequest
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public bool IsHidden { get; set; }
        public string ImagePath { get; set; }
        // public  Image { get; set; }
        public List<int> Cocktails { get; set; }
    }
}