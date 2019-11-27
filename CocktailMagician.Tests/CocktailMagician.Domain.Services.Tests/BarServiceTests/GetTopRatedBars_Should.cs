using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.BarServiceTests
{
    [TestClass]
    public class GetTopRatedBars_Should
    {
        [TestMethod]
        public async Task ReturnExactlyThreeBars()
        {
            var barEntity1 = new BarEntity()
            {
                Name = "TestBar1",
                Address = "TestAddress1",
                IsHidden = false,
                Rating = 5
            };

            var barEntity2 = new BarEntity()
            {
                Name = "TestBar2",
                Address = "TestAddress2",
                IsHidden = false,
                Rating = 4
            };

            var barEntity3 = new BarEntity()
            {
                Name = "TestBar3",
                Address = "TestAddress3",
                IsHidden = false,
                Rating = 3
            };

            var barEntity4 = new BarEntity()
            {
                Name = "TestBar4",
                Address = "TestAddress4",
                IsHidden = false,
                Rating = 2
            };
            var barEntity5 = new BarEntity()
            {
                Name = "TestBar5",
                Address = "TestAddress5",
                IsHidden = false,
                Rating = 1
            };

            var options = TestUtilities.GetOptions(nameof(ReturnExactlyThreeBars));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(barEntity1);
                await arrangeContext.Bars.AddAsync(barEntity2);
                await arrangeContext.Bars.AddAsync(barEntity3);
                await arrangeContext.Bars.AddAsync(barEntity4);
                await arrangeContext.Bars.AddAsync(barEntity5);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var listOfRatedBars = await sut.GetTopRatedBars();

                var barsCount = listOfRatedBars.Count();

                Assert.AreEqual(3, barsCount);
            }
        }

        [TestMethod]
        public async Task ReturnCorrectTopRatedCocktails()
        {
            var barEntity1 = new BarEntity()
            {
                Name = "TestBar1",
                Address = "TestAddress1",
                IsHidden = false,
                Rating = 5
            };

            var barEntity2 = new BarEntity()
            {
                Name = "TestBar2",
                Address = "TestAddress2",
                IsHidden = false,
                Rating = 4
            };

            var barEntity3 = new BarEntity()
            {
                Name = "TestBar3",
                Address = "TestAddress3",
                IsHidden = false,
                Rating = 3
            };

            var barEntity4 = new BarEntity()
            {
                Name = "TestBar4",
                Address = "TestAddress4",
                IsHidden = false,
                Rating = 2
            };
            var barEntity5 = new BarEntity()
            {
                Name = "TestBar5",
                Address = "TestAddress5",
                IsHidden = false,
                Rating = 1
            };

            var options = TestUtilities.GetOptions(nameof(ReturnCorrectTopRatedCocktails));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(barEntity1);
                await arrangeContext.Bars.AddAsync(barEntity2);
                await arrangeContext.Bars.AddAsync(barEntity3);
                await arrangeContext.Bars.AddAsync(barEntity4);
                await arrangeContext.Bars.AddAsync(barEntity5);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var listOfTopRatedBars = await sut.GetTopRatedBars();

                Assert.AreEqual("TestBar1", listOfTopRatedBars.FirstOrDefault().Name);
                Assert.AreEqual("TestBar2", listOfTopRatedBars.Skip(1).FirstOrDefault().Name);
                Assert.AreEqual("TestBar3", listOfTopRatedBars.Skip(2).FirstOrDefault().Name);
            }
        }
    }
}
