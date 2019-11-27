using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.IngredientServiceTests
{
    [TestClass]
    public class Delete_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_When_IngredientDoesntExist()
        {
            var testIngredientId = 2;

            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_When_IngredientDoesntExist));


            using (var assertContext = new AppDBContext(options))
            {
                var sut = new IngredientService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Delete(testIngredientId));
            }
        }

        [TestMethod]
        public async Task DeleteIngredient_When_IngredientExists()
        {
            var testIngredientId = 2;
            var testIngredientName = "TestIngredientName";
            var timesUsed = 1;

            var testIngredientEntity = new IngredientEntity()
            {
                Id = testIngredientId,
                Name = testIngredientName,
                TimesUsed = timesUsed
            };

            var options = TestUtilities.GetOptions(nameof(DeleteIngredient_When_IngredientExists));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(testIngredientEntity);
                await arrangeContext.SaveChangesAsync();

            }

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new IngredientService(assertContext);

                await sut.Delete(testIngredientId);

                Assert.AreEqual(0, assertContext.Ingredients.Count());
            }
        }

        [TestMethod]
        public async Task ThrowArgumentException_When_IngredientCannotBeDeleted()
        {
            var testCocktailEntityId = 1;
            var testIngredientEntityId = 5;

            var testCocktailIngredientEntity = new CocktailIngredientEntity()
            {
                CocktailEntityId = testCocktailEntityId,
                IngredientEntityId = testIngredientEntityId
            };


            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_When_IngredientCannotBeDeleted));


            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.CocktaiIngredients.AddAsync(testCocktailIngredientEntity);
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new IngredientService(assertContext);

                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Delete(testIngredientEntityId));
            }
        }
    }
}

