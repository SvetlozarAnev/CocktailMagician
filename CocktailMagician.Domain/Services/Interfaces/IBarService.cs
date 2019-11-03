using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface IBarService
    {
        Task<BarEntity> Create(Bar bar);
        Task<BarEntity> Find (Bar bar);
        Task<BarEntity> Update(Bar bar);
        Task<BarEntity> Hide(Bar bar);
    }
}