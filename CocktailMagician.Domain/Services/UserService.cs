using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Domain.Mappers;
using CocktailMagician.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CocktailMagician.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly AppDBContext context;

        public UserService(AppDBContext context)
        {
            this.context = context;
        }
        public async Task<User> GetUser(string userId)
        {
            var user = await this.context.Users
                   //.Include(u => u.CheckedOutBooks)
                   //.Include(u => u.ReservedBooks)
                   .FirstOrDefaultAsync(u => u.Id == userId);

            return user.ToContract();
        }
    }
}
