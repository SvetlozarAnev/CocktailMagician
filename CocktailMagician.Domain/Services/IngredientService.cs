using CocktailMagician.Contracts;
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
    public class IngredientService : IIngredientService
    {
        private readonly AppDBContext context;

        public IngredientService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<Ingredient> Create(Ingredient ingredient)
        {
            if (await this.context.Ingredients.SingleOrDefaultAsync(x => x.Name == ingredient.Name) != null)
            {
                throw new ArgumentException("Ingredient already exists.");
            }

            var ingredientEntity = ingredient.ToEntity();
            await this.context.Ingredients.AddAsync(ingredientEntity);
            await this.context.SaveChangesAsync();

            return ingredientEntity.ToContract();
        }
        public async Task Delete(int id)
        {
            var ingredientEntity = await this.context.Ingredients.SingleOrDefaultAsync(x => x.Id == id);
            if (ingredientEntity == null)
            {
                throw new ArgumentException("The requested ingredient is null.");
            }
            if (!this.context.CocktaiIngredients.Select(x => x.CocktailEntityId).Contains(id))
            {
                this.context.Ingredients.Remove(ingredientEntity);
            }
            else
            {
                throw new ArgumentException("The ingredient cannot be deleted.");
            }
            await this.context.SaveChangesAsync();
        }
        public async Task<IEnumerable<Ingredient>> ListAll()
        {
            var ingredients = await this.context.Ingredients
                .Select(x => x.ToContract())
                .ToListAsync();

            return ingredients;
        }
    }
}
