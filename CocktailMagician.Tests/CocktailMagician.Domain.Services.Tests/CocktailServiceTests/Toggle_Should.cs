using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.CocktailServiceTests
{
    [TestClass]
    public class Toggle_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_WhenCocktailDoesntExist()
        {
            var testCocktailId = 2;

            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_WhenCocktailDoesntExist));

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new CocktailService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Toggle(testCocktailId));
            }
        }

        [TestMethod]
        public async Task ChangeIsHiddenStatus()
        {
            var cocktailEntity = new CocktailEntity()
            {
                Id = 1,
                Name = "TestCocktailName",
                Recipe = "TestCocktailRecipe",
                IsHidden = false
            };

            var options = TestUtilities.GetOptions(nameof(ChangeIsHiddenStatus));


            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktailEntity);
                await arrangeContext.SaveChangesAsync();
            }
            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);

                var cocktail = await sut.Toggle(cocktailEntity.Id);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var cocktail = await assertContext.Cocktails.SingleOrDefaultAsync(x => x.Id == cocktailEntity.Id);
                Assert.AreEqual(true, cocktail.IsHidden);
                Assert.AreEqual(1, cocktail.Id);
            }
        }
    }
}
