using CocktailMagician.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface ICocktailService
    {
        Task<Cocktail> Create(Cocktail cocktail);
        Task<Cocktail> Get(int id);
        Task<Cocktail> Update(Cocktail cocktail);
        Task<Cocktail> Toggle(int Id);
        Task<IEnumerable<Cocktail>> ListAll();

    }
}
