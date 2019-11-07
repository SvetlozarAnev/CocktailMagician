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
    }
}
