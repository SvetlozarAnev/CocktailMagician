using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Mappers;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CocktailMagician.Domain.Services
{
    public class BarService : IBarService
    {
        private readonly AppDBContext context;

        public BarService(AppDBContext context)
        {
            this.context = context;
        }

        public async Task<Bar> Create(BarCreateRequest bar)
        {
            if (await this.context.Bars.SingleOrDefaultAsync(x => x.Name == bar.Name) != null)
            {
                throw new ArgumentException("Bar already exists.");
            }

            var barEntity = bar.ToEntity();

            await this.context.Bars.AddAsync(barEntity);
            AddCocktails(barEntity.Id, bar.Cocktails);
            await this.context.SaveChangesAsync();
            return barEntity.ToContract();
        }

        public async Task<Bar> GetBar(int id)
        {
            var barEntity = await this.context.Bars
                .Include(x => x.BarCocktails)
                .ThenInclude(x => x.CocktailEntity)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (barEntity == null)
            {
                throw new ArgumentException("There is no such bar in the database.");
            }

            this.context.Entry(barEntity).State = EntityState.Detached;
            foreach (var item in barEntity.BarCocktails)
            {
                this.context.Entry(item).State = EntityState.Detached;
            }

            return barEntity.ToContract();
        }

        public async Task<Bar> Update(BarUpdateRequest bar)
        {
            var existingBar = await GetBar(bar.Id);

            var newBarEntity = bar.ToEntity(existingBar.ToEntity());
            var existingCocktailIds = existingBar.Cocktails.Select(x => x.Id);
            var cocktailIdsToRemove = existingCocktailIds.Except(bar.CocktailIds);
            var cocktailIdsToAdd = bar.CocktailIds.Except(existingCocktailIds);
            AddCocktails(bar.Id, cocktailIdsToAdd);
            RemoveCocktails(bar.Id, cocktailIdsToRemove);
            this.context.Bars.Update(newBarEntity);
            await this.context.SaveChangesAsync();

            return await GetBar(bar.Id);
        }

        public async Task<Bar> Toggle(int id)
        {
            var barEntity = await this.context.Bars.SingleOrDefaultAsync(x => x.Id == id);
            if (barEntity == null)
            {
                throw new ArgumentException("There is no such bar.");
            }
            barEntity.IsHidden = !barEntity.IsHidden;

            await this.context.SaveChangesAsync();
            return barEntity.ToContract();
        }

        public async Task<IEnumerable<Bar>> ListAll(string role)
        {

            var bars = await this.context.Bars
                .Include(x => x.BarCocktails)
                .ThenInclude(x => x.CocktailEntity)
                               .Select(x => x.ToContract())
                               .ToListAsync();

            if (role != "Admin" || role == null)
            {
                return bars.Where(x => x.IsHidden == false);
            }

            return bars;
        }
        public async Task<IEnumerable<Cocktail>> ListCocktails()
        {
            var cocktails = await this.context.Cocktails
                .Select(x => x.ToContract())
                .ToListAsync();

            return cocktails;
        }

        private void AddCocktails(int barId, IEnumerable<int> cocktailIds)
        {
            foreach (var cocktailId in cocktailIds)
            {
                var entity = new BarCocktailEntity
                {
                    BarEntityId = barId,
                    CocktailEntityId = cocktailId
                };
                this.context.BarCocktails.Add(entity);
            }
        }

        private void RemoveCocktails(int barId, IEnumerable<int> cocktailIds)
        {
            foreach (var cocktailId in cocktailIds)
            {
                var entity = new BarCocktailEntity
                {
                    BarEntityId = barId,
                    CocktailEntityId = cocktailId
                };
                this.context.BarCocktails.Remove(entity);
            }
        }

        public async Task<double> CalculateAverageRating(Bar bar, int newRating)
        {
            var currentRatingsCount = await this.context.BarReviews.Where(x => x.BarEntityId == bar.Id).CountAsync();

            var oldRating = bar.Rating ?? 0;
            var newAverage = Math.Round(oldRating + (newRating - oldRating) / (currentRatingsCount + 1), 1);
            return newAverage;
        }

        public async Task<ICollection<Bar>> GetTopRatedBars()
        {
            var topRatedBars = await this.context.Bars
                .OrderByDescending(x => x.Rating)
                .Take(3)
                .Select(x => x.ToContract())
                .ToListAsync();

            return topRatedBars;
        }

        public async Task<ICollection<Bar>> SearchBarByName(string input)
        {
            List<Bar> output;
            if (input == null)
            {
                output = await this.context.Bars.Select(x => x.ToContract()).ToListAsync();
            }
            else
            {
                output = await this.context.Bars
                    .Select(x => x.ToContract())
                    .Where(x => x.Name.Contains(input, StringComparison.OrdinalIgnoreCase))
                    .ToListAsync();
            }
            return output;
        }

        public async Task<ICollection<Bar>> SearchBarAddress(string input)
        {
            List<Bar> output;
            if (input == null)
            {
                output = await this.context.Bars.Select(x => x.ToContract()).ToListAsync();
            }
            else
            {
                output = await this.context.Bars
                    .Select(x => x.ToContract())
                    .Where(x => x.Address.Contains(input, StringComparison.OrdinalIgnoreCase))
                    .ToListAsync();
            }
            return output;
        }
    }
}