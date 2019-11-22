using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.BarServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_When_BarAlreadyExists()
        {
            var testBarName = "TestBarName";
            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_When_BarAlreadyExists));
            var barCreateRequest = new BarCreateRequest() { Name = testBarName };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(new BarEntity() { Name = testBarName });
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new BarService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Create(barCreateRequest));
            }
        }
        [TestMethod]
        public async Task CreateBar_When_SuchBarDoesNotExist()
        {
            var testBarName = "TestBarName";
            var testBarAddress = "TestBarAddress";

            var options = TestUtilities.GetOptions(nameof(CreateBar_When_SuchBarDoesNotExist));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(new BarEntity() { Name = "RandomBarName" });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var barCreateRequest = new BarCreateRequest() { Name = testBarName, Address = testBarAddress };
                var bar = sut.Create(barCreateRequest);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                Assert.AreEqual(2, await assertContext.Bars.CountAsync());
                var bar = await assertContext.Bars.FirstOrDefaultAsync(x => x.Name == testBarName);
                Assert.IsNotNull(bar);
                Assert.AreEqual(testBarAddress, bar.Address);
            }
        }

        [TestMethod]
        public async Task AddCocktailsToBar_When_BarIsCreated()
        {
            var testBarName = "TestBarName";
            var testBarAddress = "TestBarAddress";

            var options = TestUtilities.GetOptions(nameof(AddCocktailsToBar_When_BarIsCreated));

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var barCreateRequest = new BarCreateRequest()
                {
                    Name = testBarName,
                    Address = testBarAddress,
                    Cocktails = new List<int>() { 1, 2, 3 }
                };
                var bar = sut.Create(barCreateRequest);

                await actContext.SaveChangesAsync();

                var barEntity = await actContext.Bars.FirstOrDefaultAsync(x => x.Name == testBarName);

                Assert.AreEqual(3, barEntity.BarCocktails.Count());
            }
        }

        [TestMethod]
        public async Task SaveBarInDatabase()
        {
            var testBarName = "TestBarName";
            var testBarAddress = "TestBarAddress";

            var options = TestUtilities.GetOptions(nameof(SaveBarInDatabase));

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);

                var bar = await sut.Create(new BarCreateRequest()
                {
                    Name = testBarName,
                    Address = testBarAddress,
                    Cocktails = new List<int>() { 1, 2, 3 }
                });
                await actContext.SaveChangesAsync();
            }
            using (var assertContext = new AppDBContext(options))
            {
                var barEntity = await assertContext.Bars.FirstOrDefaultAsync(b => b.Name == testBarName);

                Assert.IsNotNull(barEntity);
                Assert.AreEqual(1, assertContext.Bars.Count());
            }
        }
    }
}
