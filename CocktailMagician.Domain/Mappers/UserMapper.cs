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

        public static UserEntity ToEntity(this User contract)
        {
            if (contract == null)
            {
                return null;
            }
            return new UserEntity
            {
                UserName = contract.Name,
                Email = contract.Email
            };
        }
    }
}
