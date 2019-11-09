using CocktailMagician.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUser(string userId);
        Task<BarReview> AddBarReview(BarReview review, int barId, string userId);
        Task<CocktailReview> AddCocktailReview(CocktailReview review, int cocktilId, string userId);
    }
}
