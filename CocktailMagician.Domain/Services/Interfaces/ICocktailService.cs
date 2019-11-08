using CocktailMagician.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface ICocktailService
    {
        Task<Cocktail> Create(Cocktail cocktail);
        Task<Cocktail> GetCocktail(int id);
        Task<Cocktail> Update(Cocktail cocktail);
        Task<Cocktail> Toggle(int id);
        Task<IEnumerable<Cocktail>> ListAll(string role);
    }
}
