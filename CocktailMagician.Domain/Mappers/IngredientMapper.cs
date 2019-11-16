using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailMagician.Domain.Mappers
{
    public static class IngredientMapper
    {
        public static Ingredient ToContract(this IngredientEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new Ingredient
            {
                Id = entity.Id,
                Name = entity.Name,
                TimesUsed = entity.TimesUsed
                
            };
        }
        public static IngredientEntity ToEntity(this Ingredient contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new IngredientEntity
            {
                Name = contract.Name,
                TimesUsed = contract.TimesUsed
            };
        }
    }
}
