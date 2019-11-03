using CocktailMagician.Contracts;
using CocktailMagician.Data.Models;

namespace CocktailMagician.Domain.Mappers
{
    public static class UserMapper
    {
        public static User ToContract(this UserEntity entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new User
            {
                Id = entity.Id,
                Name = entity.UserName,
                Email = entity.Email
            };
        }
    }
}
