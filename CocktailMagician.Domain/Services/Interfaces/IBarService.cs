using CocktailMagician.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface IBarService
    {
        Task<Bar> Create(BarCreateRequest bar);
        Task<Bar> GetBar(int id);
        Task<Bar> Update(BarUpdateRequest bar);
        Task<Bar> Toggle(int id);
        Task<IEnumerable<Bar>> ListAll(string role);
        Task<IEnumerable<Cocktail>> ListCocktails();
        Task<double> CalculateAverageRating(Bar bar, int newRating);
        Task<ICollection<Bar>> GetTopRatedBars();
        Task<ICollection<Bar>> SearchBarByName(string input);
        Task<ICollection<Bar>> SearchBarAddress(string input);
    }
}