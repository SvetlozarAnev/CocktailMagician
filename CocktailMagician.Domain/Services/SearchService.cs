using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CocktailMagician.Domain.Mappers;

namespace CocktailMagician.Domain.Services
{
    public class SearchService : ISearchService
    {
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;
        private readonly AppDBContext context;

        public SearchService(IBarService barService, ICocktailService cocktailService, AppDBContext context)
        {
            this.barService = barService;
            this.cocktailService = cocktailService;
            this.context = context;
        }

        public async Task<ICollection<Bar>> SearchByName(string input)
        {
            var output = await this.context.Bars.Select(x => x.ToContract()).Where(x => x.Name.Contains(input)).ToListAsync();
            return output;
        }
    }
}
