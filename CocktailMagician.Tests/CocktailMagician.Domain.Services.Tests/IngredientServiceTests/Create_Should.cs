using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.IngredientServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_When_IngredientAlreadyExists()
        {
            var testIngredientName = "TestIngredientName";

            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_When_IngredientAlreadyExists));

            var ingredient = new Ingredient()
            { Name = testIngredientName };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(new IngredientEntity() { Name = testIngredientName });
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new IngredientService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Create(ingredient));
            }
        }

        [TestMethod]
        public async Task CreateIngredient_When_SuchIngredientDoesNotExist()
        {
            var testIngredientName = "TestIngredientName";

            var options = TestUtilities.GetOptions(nameof(CreateIngredient_When_SuchIngredientDoesNotExist));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Ingredients.AddAsync(new IngredientEntity() { Name = "RandomIngredientName" });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new IngredientService(actContext);
                var ingredient = new Ingredient() { Name = testIngredientName };
                var testIngredient = await sut.Create(ingredient);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                Assert.AreEqual(2, assertContext.Ingredients.Count());
                var cocktail = await assertContext.Ingredients.FirstOrDefaultAsync(x => x.Name == testIngredientName);
                Assert.IsNotNull(cocktail);
            }
        }


    }
}
