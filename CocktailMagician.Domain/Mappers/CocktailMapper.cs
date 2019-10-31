using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Mappers.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Domain.Mappers
{
    public class CocktailMapper : IMapper<CocktailEntity, Cocktail>
    {
        public Cocktail MapFrom(CocktailEntity entity)
            => new Cocktail
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
