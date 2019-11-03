using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    interface ICocktailService
    {
        Task<CocktailEntity> Create(Cocktail cocktail);
        Task<CocktailEntity> Find(Cocktail cocktail);
        Task<CocktailEntity> Update(Cocktail cocktail);
        Task<CocktailEntity> Hide(Cocktail cocktail);
    }
}
