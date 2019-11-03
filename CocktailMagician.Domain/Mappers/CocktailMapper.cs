using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Domain.Mappers
{
    public static class CocktailMapper
    {
        public static Cocktail ToContract(CocktailEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new Cocktail
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
}
