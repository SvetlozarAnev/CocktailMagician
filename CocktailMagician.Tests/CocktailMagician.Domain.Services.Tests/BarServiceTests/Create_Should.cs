using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.BarServiceTests
{
    [TestClass]
    public class Create_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_WhenBarExists()
        {
            var testBarName = "peshoBar";
            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_WhenBarExists));
            var barContract = new Bar() { Name = testBarName };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(new BarEntity() { Name = testBarName });
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new BarService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Create(barContract));
            }
        }
        [TestMethod]
        public async Task CreatesBar_When_BarDoesNotExist()
        {
            var testBarName = "peshoBar";
            var testBarAddress = "testAddress";

            var options = TestUtilities.GetOptions(nameof(CreatesBar_When_BarDoesNotExist));

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(new BarEntity() { Name = "randomBarName" });
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var barContract = new Bar() { Name = testBarName, Address = testBarAddress };
                var bar = sut.Create(barContract);
            }

            using (var assertContext = new AppDBContext(options))
            {
                Assert.AreEqual(2, await assertContext.Bars.CountAsync());
                var bar = await assertContext.Bars.FirstOrDefaultAsync(x => x.Name == testBarName);
                Assert.IsNotNull(bar);
                Assert.AreEqual(testBarAddress, bar.Address);
            }
        }

        // AddCocktails method to be tested..

        

    }
}
