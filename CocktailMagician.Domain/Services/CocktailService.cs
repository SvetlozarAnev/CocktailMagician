﻿using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Domain.Mappers;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Cocktail> Create(Cocktail cocktail)
        {
            if (await this.context.Cocktails.SingleOrDefaultAsync(x => x.Name == cocktail.Name) != null)
            {
                throw new ArgumentException("Bar already exists.");
            }
            var cocktailEntity = cocktail.ToEntity();
            await this.context.Cocktails.AddAsync(cocktailEntity);
            await this.context.SaveChangesAsync();

            return cocktailEntity.ToContract();
        }
        public async Task<Cocktail> GetCocktail(int id)
        {
            var cocktailEntity = await this.context.Cocktails
                .Include(x => x.CocktailIngredients)
                .ThenInclude(x => x.IngredientEntity)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (cocktailEntity == null)
            {
                throw new ArgumentException("The requested Cocktail is null.");
            }
            return cocktailEntity.ToContract();
        }

        public async Task<Cocktail> Update(Cocktail cocktail)
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
            await this.context.SaveChangesAsync();
            
            return cocktailEntity.ToContract();
        }
        public async Task<Cocktail> Toggle(int id)
        {
            var cocktailEntity = await this.context.Cocktails.SingleOrDefaultAsync(x => x.Id == id);
            if (cocktailEntity == null)
            {
                throw new ArgumentException("The requested cocktail is null.");
            }
            cocktailEntity.IsHidden = !cocktailEntity.IsHidden;

            await this.context.SaveChangesAsync();

            return cocktailEntity.ToContract();
        }

        public async Task<IEnumerable<Cocktail>> ListAll(string role)
        {
            var cocktails = await this.context.Cocktails
                .Select(x => x.ToContract())
                .ToListAsync();

            if (role != "Admin" || role == null)
            {
                return cocktails.Where(x => x.IsHidden == false);
            }

            return cocktails;
        }

        public async Task<double> CalculateAverageRating(Cocktail cocktail, int newRating)
        {
            var currentRatingsCount = await this.context.CocktailReviews.Where(x => x.CocktailEntityId == cocktail.Id).CountAsync();

            var oldRating = cocktail.Rating ?? 0;
            var newAverage = oldRating + (newRating - oldRating) / (currentRatingsCount + 1);
            return newAverage;
        }
    }
}

