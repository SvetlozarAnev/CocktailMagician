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

        public async Task<Bar> Create(Bar bar)
        {
            if (await this.context.Bars.SingleOrDefaultAsync(x => x.Name == bar.Name) != null)
            {
                throw new ArgumentException("Bar already exists.");
            }

            var barEntity = bar.ToEntity();

            await this.context.Bars.AddAsync(barEntity);
            await this.context.SaveChangesAsync();
            await AddCocktails(barEntity.Id, bar.Cocktails);
            return barEntity.ToContract();
        }

        private async Task AddCocktails(int barId, IEnumerable<string> cocktails)
        {
            foreach (var item in cocktails)
            {
                var entity = new BarCocktailEntity
                {
                    BarEntityId = barId,
                    CocktailEntityId = int.Parse(item)
                };
                this.context.BarCocktails.Add(entity);
            }
            await this.context.SaveChangesAsync();
        }

        public async Task<Bar> GetBar(int id)
        {
            var barEntity = await this.context.Bars
                .Include(x => x.BarCocktails)
                .ThenInclude(x => x.CocktailEntity)
                .SingleOrDefaultAsync(x => x.Id == id);

            if (barEntity == null)
            {
                throw new ArgumentException("The requested Bar is null.");
            }

            return barEntity.ToContract();
        }
        public async Task<Bar> Update(Bar bar)
        {
            var barEntity = await this.context.Bars.SingleOrDefaultAsync(x => x.Id == bar.Id);
            if (barEntity == null)
            {
                throw new ArgumentException("There is no such bar in the database.");
            }

            barEntity.Name = bar.Name;
            barEntity.Address = bar.Address;
            barEntity.Rating = bar.Rating;
            barEntity.IsHidden = bar.IsHidden;
            barEntity.ImagePath = bar.ImagePath;
            await this.context.SaveChangesAsync();
            await AddCocktails(barEntity.Id, bar.Cocktails);
            return barEntity.ToContract();
        }
        public async Task<Bar> Toggle(int id)
        {
            var barEntity = await this.context.Bars.SingleOrDefaultAsync(x => x.Id == id);
            if (barEntity == null)
            {
                throw new ArgumentException("The requested Bar is null.");
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

        public async Task<double> CalculateAverageRating(Bar bar, int newRating)
        {
            var currentRatingsCount = await this.context.BarReviews.Where(x => x.BarEntityId == bar.Id).CountAsync();

            var oldRating = bar.Rating ?? 0;
            var newAverage = Math.Round(oldRating + (newRating - oldRating) / (currentRatingsCount + 1), 1);
            return newAverage;
        }
    }
}