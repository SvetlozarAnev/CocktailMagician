using CocktailMagician.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface IBarService
    {
        Task<Bar> Create(Bar bar);
        Task<Bar> Find (int id);
        Task<Bar> Update(Bar bar);
        Task<Bar> Hide(Bar bar);
        Task<IEnumerable<Bar>> ListAll();
    }
}