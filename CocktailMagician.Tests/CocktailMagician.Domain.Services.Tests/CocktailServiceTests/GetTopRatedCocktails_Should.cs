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
    public class GetTopRatedCocktails_Should
    {
        [TestMethod]
        public async Task ReturnExactlyThreeCocktails()
        {
            var cocktailEntity1 = new CocktailEntity()
            {
                Name = "TestCocktail1",
                Recipe = "TestCocktailRecipe1",
                IsHidden = false,
                Rating = 5
            };

            var cocktailEntity2 = new CocktailEntity()
            {
                Name = "TestCocktail2",
                Recipe = "TestCocktailRecipe2",
                IsHidden = false,
                Rating = 4
            };

            var cocktailEntity3 = new CocktailEntity()
            {
                Name = "TestCocktail3",
                Recipe = "TestCocktailRecipe3",
                IsHidden = false,
                Rating = 3
            };

            var cocktailEntity4 = new CocktailEntity()
            {
                Name = "TestCocktail4",
                Recipe = "TestCocktailRecipe3",
                IsHidden = false,
                Rating = 2
            };
            var cocktailEntity5 = new CocktailEntity()
            {
                Name = "TestCocktail5",
                Recipe = "TestCocktailRecipe3",
                IsHidden = false,
                Rating = 1
            };

            var options = TestUtilities.GetOptions(nameof(ReturnExactlyThreeCocktails));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktailEntity1);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity2);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity3);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity4);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity5);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                var listOfRatedCocktails = await sut.GetTopRatedCoktails();

                var cocktailsCount = listOfRatedCocktails.Count();

                Assert.AreEqual(3, cocktailsCount);
            }
        }

        [TestMethod]
        public async Task ReturnCorrectTopRatedCocktails()
        {
            var cocktailEntity1 = new CocktailEntity()
            {
                Name = "TestCocktail1",
                Recipe = "TestCocktailRecipe1",
                IsHidden = false,
                Rating = 5
            };

            var cocktailEntity2 = new CocktailEntity()
            {
                Name = "TestCocktail2",
                Recipe = "TestCocktailRecipe2",
                IsHidden = false,
                Rating = 4
            };

            var cocktailEntity3 = new CocktailEntity()
            {
                Name = "TestCocktail3",
                Recipe = "TestCocktailRecipe3",
                IsHidden = false,
                Rating = 3
            };

            var cocktailEntity4 = new CocktailEntity()
            {
                Name = "TestCocktail4",
                Recipe = "TestCocktailRecipe4",
                IsHidden = true,
                Rating = 2
            };
            var cocktailEntity5 = new CocktailEntity()
            {
                Name = "TestCocktail5",
                Recipe = "TestCocktailRecipe5",
                IsHidden = true,
                Rating = 1
            };

            var options = TestUtilities.GetOptions(nameof(ReturnCorrectTopRatedCocktails));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Cocktails.AddAsync(cocktailEntity1);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity2);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity3);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity4);
                await arrangeContext.Cocktails.AddAsync(cocktailEntity5);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                var listOfTopRatedCocktails = await sut.GetTopRatedCoktails();

                Assert.AreEqual("TestCocktail1", listOfTopRatedCocktails.FirstOrDefault().Name);
                Assert.AreEqual("TestCocktail2", listOfTopRatedCocktails.Skip(1).FirstOrDefault().Name);
                Assert.AreEqual("TestCocktail3", listOfTopRatedCocktails.Skip(2).FirstOrDefault().Name);
            }
        }
    }
}
