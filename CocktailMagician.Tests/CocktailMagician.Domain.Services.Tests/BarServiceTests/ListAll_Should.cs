using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.BarServiceTests
{
    [TestClass]
    public class ListAll_Should
    {
        [TestMethod]
        public async Task ReturnAllNotHiddenBars_WhenUserIsNotAdmin()
        {
            const string userRole = "User";

            var barEntity1 = new BarEntity()
            {
                Name = "TestBar1",
                Address = "TestAddress1",
                IsHidden = false
            };

            var barEntity2 = new BarEntity()
            {
                Name = "TestBar2",
                Address = "TestAddress2",
                IsHidden = false
            };

            var barEntity3 = new BarEntity()
            {
                Name = "TestBar3",
                Address = "TestAddress3",
                IsHidden = true
            };

            var options = TestUtilities.GetOptions(nameof(ReturnAllNotHiddenBars_WhenUserIsNotAdmin));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(barEntity1);
                await arrangeContext.Bars.AddAsync(barEntity2);
                await arrangeContext.Bars.AddAsync(barEntity3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var listOfBars = await sut.ListAll(userRole);
                var count = listOfBars.Count();

                Assert.AreEqual(2, count);
            }
        }

        [TestMethod]
        public async Task ReturnAllBars_WhenUserIsAdmin()
        {
            const string userRole = "Admin";

            var barEntity1 = new BarEntity()
            {
                Name = "TestBar1",
                Address = "TestAddress1",
                IsHidden = false
            };

            var barEntity2 = new BarEntity()
            {
                Name = "TestBar2",
                Address = "TestAddress2",
                IsHidden = false
            };

            var barEntity3 = new BarEntity()
            {
                Name = "TestBar3",
                Address = "TestAddress3",
                IsHidden = true
            };

            var options = TestUtilities.GetOptions(nameof(ReturnAllBars_WhenUserIsAdmin));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(barEntity1);
                await arrangeContext.Bars.AddAsync(barEntity2);
                await arrangeContext.Bars.AddAsync(barEntity3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var listOfBars = await sut.ListAll(userRole);
                var count = listOfBars.Count();

                Assert.AreEqual(3, count);
            }
        }
    }
}
