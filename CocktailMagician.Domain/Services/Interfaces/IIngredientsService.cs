using CocktailMagician.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface IIngredientService
    {
        Task<Ingredient> Create(Ingredient ingredient);
        Task Delete(int id);
        Task<IEnumerable<Ingredient>> ListAll();
    }
}
