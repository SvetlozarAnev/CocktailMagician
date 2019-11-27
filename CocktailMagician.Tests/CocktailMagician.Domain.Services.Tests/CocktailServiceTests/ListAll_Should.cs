using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.CocktailServiceTests
{
    [TestClass]
    public class ListAll_Should
    {
        [TestMethod]
        public async Task ReturnAllNotHiddenCocktails_WhenUserIsNotAdmin()
        {
            const string userRole = "User";

            var cocktailEntity1 = new CocktailEntity()
            {
                Name = "TestCicktail1",
                Recipe = "TestCocktailRecipe1",
                IsHidden = false
            };

            var cocktailEntity2 = new CocktailEntity()
            {
                Name = "TestCicktail2",
                Recipe = "TestCocktailRecipe2",
                IsHidden = false
            };

            var cocktailEntity3 = new CocktailEntity()
            {
                Name = "TestCicktail3",
                Recipe = "TestCocktailRecipe3",
                IsHidden = true
            };

            var options = TestUtilities.GetOptions(nameof(ReturnAllNotHiddenCocktails_WhenUserIsNotAdmin));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktailEntity1);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity2);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                var listOfCocktails = await sut.ListAll(userRole);
                var count = listOfCocktails.Count();

                Assert.AreEqual(2, count);
            }
        }

        [TestMethod]
        public async Task ReturnAllCocktails_WhenUserIsAdmin()
        {
            const string userRole = "Admin";

            var cocktailEntity1 = new CocktailEntity()
            {
                Name = "TestCocktail1",
                Recipe = "TestCocktailRecipe1",
                IsHidden = false
            };

            var cocktailEntity2 = new CocktailEntity()
            {
                Name = "TestCocktail2",
                Recipe = "TestCocktailRecipe1",
                IsHidden = false
            };

            var cocktailEntity3 = new CocktailEntity()
            {
                Name = "TestCocktail3",
                Recipe = "TestCocktailRecipe1",
                IsHidden = true
            };

            var options = TestUtilities.GetOptions(nameof(ReturnAllCocktails_WhenUserIsAdmin));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktailEntity1);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity2);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                var listOfCocktails = await sut.ListAll(userRole);
                var count = listOfCocktails.Count();

                Assert.AreEqual(3, count);
            }
        }
    }
}
