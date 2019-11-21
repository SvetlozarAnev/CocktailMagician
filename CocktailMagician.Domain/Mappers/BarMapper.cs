using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
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
                .Select(x => x.CocktailEntity.ToContract())
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
                Id = contract.Id,
                Name = contract.Name,
                Address = contract.Address,
                Rating = contract.Rating,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath
            };
        }
        public static BarEntity ToEntity(this BarCreateRequest contract)
        {
            if (contract == null)
            {
                return null;
            }
         
            return new BarEntity
            {
                Name = contract.Name,
                Address = contract.Address,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath
            };
        }
        public static BarEntity ToEntity(this BarUpdateRequest contract, BarEntity entity)
        {
            if (contract == null)
            {
                return null;
            }

            return new BarEntity
            {
                Id = entity.Id,
                Name = contract.Name,
                Address = contract.Address,
                Rating = entity.Rating,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath
            };
        }


        public static BarUpdateRequest ToUpdateRequest(this Bar contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new BarUpdateRequest
            {
                Id = contract.Id,
                Name = contract.Name,
                Address = contract.Address,
                //  Rating = contract.Rating,
                IsHidden = contract.IsHidden,
                ImagePath = contract.ImagePath,
                CocktailIds = contract.Cocktails?.Select(x => x.Id).ToList()
            };
        }
    }
}
