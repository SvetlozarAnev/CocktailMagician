using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.CocktailServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_When_CocktailAlreadyExists()
        {
            var testCocktailName = "TestCocktailName";
            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_When_CocktailAlreadyExists));
            var cocktailCreateRequest = new CocktailCreateRequest() { Name = testCocktailName };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(new CocktailEntity() { Name = testCocktailName });
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new CocktailService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Create(cocktailCreateRequest));
            }
        }

        [TestMethod]
        public async Task CreateCocktail_When_SuchCocktailDoesNotExist()
        {
            var testCocktailName = "TestCocktailName";
           var testCocktailRecipe = "Test cocktail recipe";

            var options = TestUtilities.GetOptions(nameof(CreateCocktail_When_SuchCocktailDoesNotExist));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(new CocktailEntity() { Name = "RandomCocktailName" });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                var cocktailCreateRequest = new CocktailCreateRequest() { Name = testCocktailName, Recipe = testCocktailRecipe };
                var cocktail = sut.Create(cocktailCreateRequest);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                Assert.AreEqual(2, await assertContext.Cocktails.CountAsync());
                var cocktail = await assertContext.Cocktails.FirstOrDefaultAsync(x => x.Name == testCocktailName);
                Assert.IsNotNull(cocktail);
                Assert.AreEqual(testCocktailRecipe, cocktail.Recipe);
            }
        }

    }
}
