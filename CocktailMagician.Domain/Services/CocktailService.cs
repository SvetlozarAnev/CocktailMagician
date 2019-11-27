using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
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

        public async Task<Cocktail> Create(CocktailCreateRequest cocktail)
        {
            if (await this.context.Cocktails.SingleOrDefaultAsync(x => x.Name == cocktail.Name) != null)
            {
                throw new ArgumentException("Cocktail already exists.");
            }
            var cocktailEntity = cocktail.ToEntity();
            await this.context.Cocktails.AddAsync(cocktailEntity);

            await this.context.SaveChangesAsync();
            AddIngredients(cocktailEntity.Id, cocktail.Ingredients);
            await IncrementIngredientCounter(cocktail.Ingredients);
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
                throw new ArgumentException("There is no such cocktail in the database.");
            }

            this.context.Entry(cocktailEntity).State = EntityState.Detached;
            foreach (var item in cocktailEntity.CocktailIngredients)
            {
                this.context.Entry(item).State = EntityState.Detached;
            }

            return cocktailEntity.ToContract();
        }

        public async Task<Cocktail> Update(CocktailUpdateRequest cocktail)
        {
            var existingCocktail = await GetCocktail(cocktail.Id);

            var newCocktailEntity = cocktail.ToEntity(existingCocktail.ToEntity());

            var existingIngredientsIds = existingCocktail.Ingredients.Select(x => x.Id);
            var ingredientsIdsToRemove = existingIngredientsIds.Except(cocktail.IngredientIds);
            var ingredientsIdsToAdd = cocktail.IngredientIds.Except(existingIngredientsIds);

            AddIngredients(cocktail.Id, ingredientsIdsToAdd);
            await IncrementIngredientCounter(ingredientsIdsToAdd);
            RemoveIngredients(cocktail.Id, ingredientsIdsToRemove);
            await DecrementIngredientCounter(ingredientsIdsToRemove);

            this.context.Cocktails.Update(newCocktailEntity);

            await this.context.SaveChangesAsync();
            return await GetCocktail(cocktail.Id);
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
               .Include(x => x.CocktailIngredients)
                   .ThenInclude(x => x.IngredientEntity)
               .Select(x => x.ToContract())
               .ToListAsync();

            if (role != "Admin" || role == null)
            {
                return cocktails.Where(x => x.IsHidden == false);
            }

            return cocktails;
        }

        public async Task<IEnumerable<Ingredient>> ListIngredients()
        {
            var ingredients = await this.context.Ingredients
                .Select(x => x.ToContract())
                .ToListAsync();

            return ingredients;
        }

        private void AddIngredients(int cocktailId, IEnumerable<int> ingredientIds)
        {
            foreach (var ingredientId in ingredientIds)
            {
                var entity = new CocktailIngredientEntity
                {
                    CocktailEntityId = cocktailId,
                    IngredientEntityId = ingredientId,
                };

                this.context.CocktaiIngredients.Add(entity);
            }
        }

        private void RemoveIngredients(int cocktailId, IEnumerable<int> ingredientIds)
        {
            foreach (var ingredientId in ingredientIds)
            {
                var entity = new CocktailIngredientEntity
                {
                    CocktailEntityId = cocktailId,
                    IngredientEntityId = ingredientId,

                };

                this.context.CocktaiIngredients.Remove(entity);
            }
        }

        private async Task IncrementIngredientCounter(IEnumerable<int> ingredientIds)
        {
            foreach (var ingredientId in ingredientIds)
            {
                var entity = await this.context.Ingredients.Where(x => x.Id == ingredientId).SingleOrDefaultAsync();
                entity.TimesUsed++;
            }
            await this.context.SaveChangesAsync();
        }

        private async Task DecrementIngredientCounter(IEnumerable<int> ingredientIds)
        {
            foreach (var ingredientId in ingredientIds)
            {
                var entity = await this.context.Ingredients.Where(x => x.Id == ingredientId).SingleOrDefaultAsync();
                entity.TimesUsed--;
            }
            await this.context.SaveChangesAsync();
        }

        public async Task<double> CalculateAverageRating(Cocktail cocktail, int newRating)
        {
            var currentRatingsCount = await this.context.CocktailReviews.Where(x => x.CocktailEntityId == cocktail.Id).CountAsync();

            var oldRating = cocktail.Rating ?? 0;
            var newAverage = Math.Round(oldRating + (newRating - oldRating) / (currentRatingsCount + 1), 1);
            return newAverage;
        }

        public async Task<ICollection<Cocktail>> GetTopRatedCoktails()
        {
            var topRatedCocktails = await this.context.Cocktails
                .OrderByDescending(x => x.Rating)
                .Take(3)
                .Select(x => x.ToContract())
                .ToListAsync();

            return topRatedCocktails;
        }

        public async Task<ICollection<Cocktail>> SearchCocktailByName(string input)
        {
            List<Cocktail> output;
            if (input == null)
            {
                output = await this.context.Cocktails.Select(x => x.ToContract()).ToListAsync();
            }
            else
            {
                output = await this.context.Cocktails
                    .Select(x => x.ToContract())
                    .Where(x => x.Name.Contains(input, StringComparison.OrdinalIgnoreCase))
                    .ToListAsync();
            }
            return output;
        }

        public async Task<ICollection<Bar>> SearchCocktailByIngredient(string input)
        {
            //List<Cocktail> output;
            //if (input == null)
            //{
            //    output = await this.context.Cocktails.Select(x => x.ToContract()).ToListAsync();
            //}
            //else
            //{
            //    output = await this.context.Cocktails
            //        .Select(x => x.ToContract())
            //        .Select(x => x.Ingredients).ForEachAsync(y=>y.Contains(input, StringComparison.OrdinalIgnoreCase))
            //        .ToListAsync();
            //}
            //return output;
            return new List<Bar>();
        }

        public async Task<ICollection<Bar>> SearchCocktailByBar(string input)
        {
            //List<Bar> output;
            //if (input == null)
            //{
            //    output = await this.context.Bars.Select(x => x.ToContract()).ToListAsync();
            //}
            //else
            //{
            //    output = await this.context.Bars
            //        .Select(x => x.ToContract())
            //        .Where(x => x.Address.Contains(input, StringComparison.OrdinalIgnoreCase))
            //        .ToListAsync();
            //}
            //return output;
            return new List<Bar>();
        }

        Task<ICollection<Cocktail>> ICocktailService.SearchCocktailByIngredient(string input)
        {
            throw new NotImplementedException();
        }

        Task<ICollection<Cocktail>> ICocktailService.SearchCocktailByBar(string input)
        {
            throw new NotImplementedException();
        }
    }
}