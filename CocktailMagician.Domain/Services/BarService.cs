using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<BarEntity> Create(Bar bar)
        {
            if (await this.context.Bars.SingleOrDefaultAsync(x => x.Name == bar.Name) != null)
            {
                throw new ArgumentException("Bar already exists.");
            }
            var barEntity = new BarEntity()
            {
                Id = bar.Id,
                Name = bar.Name,
                Address = bar.Address,
                Rating = bar.Rating,
                IsHidden = bar.IsHidden,
                ImagePath = bar.ImagePath
            };
            return barEntity;
        }

        public async Task<BarEntity> Find(Bar bar)
        {
            if (bar == null)
            {
                throw new ArgumentException("The requested Bar is null.");
            }
            return await this.context.Bars.SingleOrDefaultAsync(x => x.Name == bar.Name);
        }

        public async Task<BarEntity> Hide(Bar bar)
        {
            if (bar == null)
            {
                throw new ArgumentException("The requested Bar is null.");
            }
            var barEntity = await this.context.Bars.SingleOrDefaultAsync(x => x.Name == bar.Name);
            if (barEntity != null && barEntity.IsHidden == false)
            {
                barEntity.IsHidden = true;
            }
            return barEntity;
        }

        public async Task<BarEntity> Update(Bar bar)
        {
            var barEntity = await this.context.Bars.SingleOrDefaultAsync(x => x.Name == bar.Name);
            if (barEntity==null)
            {
                throw new ArgumentException("There is no such bar in the database.");
            }

            barEntity.Name = bar.Name;
            barEntity.Address = bar.Address;
            barEntity.Rating = bar.Rating;
            barEntity.IsHidden = bar.IsHidden;
            barEntity.ImagePath = bar.ImagePath;

            return barEntity;
        }
    }
}
