using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services
{
    public class CocktailService : ICocktailService
    {
        private readonly AppDBContext context;

        public CocktailService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<CocktailEntity> Create(Cocktail cocktail)
        {
            if (await this.context.Cocktails.SingleOrDefaultAsync(x => x.Id == cocktail.Id) != null)
            {
                throw new ArgumentException("Bar already exists.");
            }
            var cocktailEntity = new CocktailEntity()
            {
                Id = cocktail.Id,
                Name = cocktail.Name,
                Rating = cocktail.Rating,
                IsHidden = cocktail.IsHidden,
                ImagePath = cocktail.ImagePath
            };
            return cocktailEntity;
        }
        public async Task<CocktailEntity> Find(Cocktail cocktail)
        {
            if (cocktail == null)
            {
                throw new ArgumentException("The requested Cocktail is null.");
            }
            return await this.context.Cocktails.SingleOrDefaultAsync(x => x.Id == cocktail.Id);
        }


        public async Task<CocktailEntity> Update(Cocktail cocktail)
        {
            var cocktailEntity = await this.context.Cocktails.SingleOrDefaultAsync(x => x.Id == cocktail.Id);
            if (cocktailEntity == null)
            {
                throw new ArgumentException("There is no such bar in the database.");
            }
            cocktailEntity.Name = cocktail.Name;
            cocktailEntity.Recipe = cocktail.Recipe;
            cocktailEntity.Rating = cocktail.Rating;
            cocktailEntity.IsHidden = cocktail.IsHidden;
            cocktailEntity.ImagePath = cocktail.ImagePath;

            return cocktailEntity;
        }
        public async Task<CocktailEntity> Hide(Cocktail cocktail)
        {
            if (cocktail == null)
            {
                throw new ArgumentException("The requested cocktail is null.");
            }
            var cocktailEntity = await this.context.Cocktails.SingleOrDefaultAsync(x => x.Id == cocktail.Id);
            if (cocktailEntity != null && cocktailEntity.IsHidden == false)
            {
                cocktailEntity.IsHidden = true;
            }
            return cocktailEntity;
        }
    }
}
