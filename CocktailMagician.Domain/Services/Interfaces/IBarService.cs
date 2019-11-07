using CocktailMagician.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface IBarService
    {
        Task<Bar> Create(Bar bar);
        Task<Bar> Get (int id);
        Task<Bar> Update(Bar bar);
        Task<Bar> Toggle(int Id);
        Task<IEnumerable<Bar>> ListAll();
    }
}