using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using System.Linq;

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
                ImagePath = entity.ImagePath,
                Cocktails = entity.BarCocktails?
                .Select(x => x.CocktailEntity.ToContract().Name)           
            };

        }
        public static BarEntity ToEntity(this Bar contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new BarEntity
            {
                Name = contract.Name,
                Address = contract.Address,
                Rating = contract.Rating,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath
            };
        }
    }
}
