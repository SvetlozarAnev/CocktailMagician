using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Domain.Mappers
{
    public static class BarMapper 
    {
        public static Bar ToContract(this BarEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new Bar
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
}
