using CocktailMagician.Contracts.Mappers;
using CocktailMagician.Contracts.Objects;
using CocktailMagician.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Mappers
{
    public class BarViewMapper : IViewModelMapper<Bar, BarViewModel>
    {
        public BarViewModel MapFrom(Bar entity)
=>
    new BarViewModel()
    {
        Id = entity.Id,
        Name = entity.Name,
        Address = entity.Address,
        Rating = entity.Rating,
        IsHidden = entity.IsHidden,
        ImagePath = entity.ImagePath
    };

    }
}
