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
            

            var barEntity = new BarEntity()
            {
               // Id = bar.Id,
                Name = bar.Name,
                Address = bar.Address,
                Rating = bar.Rating,
                IsHidden = bar.IsHidden,
                ImagePath = bar.ImagePath
            };
            await this.context.SaveChangesAsync();

            return barEntity.ToContract();
        }
        public async Task<Bar> Find(int id)
        {
            var barEntity = await this.context.Bars.SingleOrDefaultAsync(x => x.Id == id);

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

            return barEntity.ToContract();
        }
        public async Task<Bar> Hide(Bar bar)
        {
            if (bar == null)
            {
                throw new ArgumentException("The requested Bar is null.");
            }
            var barEntity = await this.context.Bars.SingleOrDefaultAsync(x => x.Id == bar.Id);
            if (barEntity != null && barEntity.IsHidden == false)
            {
                barEntity.IsHidden = true;
            }
            else if (barEntity != null && barEntity.IsHidden == true)
            {
                barEntity.IsHidden = false;
            }
            await this.context.SaveChangesAsync();
            return barEntity.ToContract();
        }

        public async Task<IEnumerable<Bar>> ListAll()
        {
            var bars = await this.context.Bars.Select(x => x.ToContract()).ToListAsync();
            return bars;
        }

    }
}
