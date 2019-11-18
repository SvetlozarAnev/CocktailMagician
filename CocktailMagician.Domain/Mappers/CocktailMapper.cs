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
                .Select(x => x.IngredientEntity.ToContract())
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
                Id = contract.Id,
                Name = contract.Name,
                Recipe = contract.Recipe,
                Rating = contract.Rating,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath
            };
        }
        public static CocktailEntity ToEntity(this CocktailCreateRequest contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new CocktailEntity
            {
                Name = contract.Name,
                Recipe = contract.Recipe,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath,
            };
        }
        public static CocktailEntity ToEntity(this CocktailUpdateRequest contract, CocktailEntity entity)
        {
            if (contract == null)
            {
                return null;
            }
            return new CocktailEntity
            {
                Id = entity.Id,
                Name = contract.Name,
                Recipe = contract.Recipe,
                Rating = entity.Rating,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath
            };
        }

        public static CocktailUpdateRequest ToUpdateRequest(this Cocktail contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new CocktailUpdateRequest
            {
                Id = contract.Id,
                Name = contract.Name,
                Recipe = contract.Recipe,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath,
                IngredientIds = contract.Ingredients?.Select(x => x.Id).ToList()
            };
        }
    }
}
