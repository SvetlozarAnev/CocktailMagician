using CocktailMagician.Contracts.Mappers;
using CocktailMagician.Contracts.Objects;
using CocktailMagician.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Mappers
{
    public class CocktailViewMapper : IViewModelMapper<Cocktail, CocktailViewModel>
    {
        public CocktailViewModel MapFrom(Cocktail entity)
=>
    new CocktailViewModel()
    {
        Id = entity.Id,
        Name = entity.Name,
        Recipe = entity.Recipe,
        Rating = entity.Rating,
        IsHidden = entity.IsHidden,
        ImagePath = entity.ImagePath
    };
    }
}
