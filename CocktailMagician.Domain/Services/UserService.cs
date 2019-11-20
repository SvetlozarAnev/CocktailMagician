using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Domain.Mappers;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext context;
        private readonly IBarService barService;
        private readonly ICocktailService cocktailService;

        public UserService(AppDBContext context, IBarService barService, ICocktailService cocktailService)
        {
            this.context = context;
            this.barService = barService;
            this.cocktailService = cocktailService;
        }
        public async Task<User> GetUser(string userId)
        {
            var user = await this.context.Users
                .Include(x => x.BarReviews)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user.ToContract();
        }

        public async Task<BarReview> AddBarReview(BarReview review, int barId, string userId)
        {
            var bar = await this.context.Bars.Where(x => x.Id == barId).SingleOrDefaultAsync();
            bar.Rating = await this.barService.CalculateAverageRating(bar.ToContract(), review.Rating);

            var reviewEntity = review.ToEntity();   
            reviewEntity.BarEntityId = barId;
            reviewEntity.UserEntityId = userId;

            await this.context.BarReviews.AddAsync(reviewEntity);
            this.context.Bars.Update(bar);
            await this.context.SaveChangesAsync();

            return reviewEntity.ToContract();
        }
        public async Task<CocktailReview> AddCocktailReview(CocktailReview review, int cocktailId, string userId)
        {
            var cocktail = await this.context.Cocktails.Where(x => x.Id == cocktailId).SingleOrDefaultAsync();
            cocktail.Rating = await this.cocktailService.CalculateAverageRating(cocktail.ToContract(), review.Rating);
            var reviewEntity = review.ToEntity();
            reviewEntity.CocktailEntityId = cocktailId;
            reviewEntity.UserEntityId = userId;

            await this.context.CocktailReviews.AddAsync(reviewEntity);
            await this.context.SaveChangesAsync();

            return reviewEntity.ToContract();
        }

    }
}
