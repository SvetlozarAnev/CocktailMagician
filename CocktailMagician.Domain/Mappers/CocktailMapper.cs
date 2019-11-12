using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using System.Linq;

namespace CocktailMagician.Domain.Mappers
{
    public static class CocktailMapper
    {
        public static Cocktail ToContract(this CocktailEntity entity)
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
                ImagePath = entity.ImagePath,
                Ingredients = entity.CocktailIngredients?
                .Select(x => x.IngredientEntity.ToContract().Name)
            };
        }
        public static CocktailEntity ToEntity(this Cocktail contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new CocktailEntity
            {
                Name = contract.Name,
                Recipe = contract.Recipe,
                Rating = contract.Rating,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath
            };
        }
    }
}
