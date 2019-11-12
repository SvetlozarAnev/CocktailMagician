using CocktailMagician.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface IBarService
    {
        Task<Bar> Create(Bar bar);
        Task<Bar> GetBar (int id);
        Task<Bar> Update(Bar bar);
        Task<Bar> Toggle(int id);
        Task<IEnumerable<Bar>> ListAll(string role);
        Task<IEnumerable<Cocktail>> ListCocktails();
        Task<double> CalculateAverageRating(Bar bar, int newRating);
    }
}