using CocktailMagician.Data;
using Microsoft.EntityFrameworkCore;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests
{

    public static class TestUtilities
    {
        public static DbContextOptions<AppDBContext> GetOptions(string databaseName)
        {
            return new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;
        }
    }
}

