using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CocktailMagician.Contracts;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface ISearchService
    {
        Task<ICollection<Bar>> SearchByName(string input);
    }
}
