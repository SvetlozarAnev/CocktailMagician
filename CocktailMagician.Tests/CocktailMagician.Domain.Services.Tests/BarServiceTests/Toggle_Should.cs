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

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.BarServiceTests
{
    [TestClass]
    public class Toggle_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_WhenBarDoesntExist()
        {
            var testBarId = 2;

            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_WhenBarDoesntExist));

            using (var assertContext = new AppDBContext(options))
            {
                var sut = new BarService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.Toggle(testBarId));
            }
        }

        [TestMethod]
        public async Task ChangeIsHiddenStatus()
        {
            var barEntity = new BarEntity()
            {
                Id = 1,
                Name = "TestBarName",
                Address = "TestBarAddress",
                IsHidden = false
            };

            var options = TestUtilities.GetOptions(nameof(ChangeIsHiddenStatus));


            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.Bars.AddAsync(barEntity);
                await arrangeContext.SaveChangesAsync();
            }
            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);

                var bar = await sut.Toggle(barEntity.Id);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var bar = await assertContext.Bars.SingleOrDefaultAsync(x => x.Id == barEntity.Id);
                Assert.AreEqual(true, bar.IsHidden);
                Assert.AreEqual(1, barEntity.Id);
            }
        }
    }
}

