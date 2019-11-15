using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.BarServiceTests
{
    [TestClass]
    public class GetBar_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_WhenBarIsMissing()
        {
            var testBarID = 1;
            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_WhenBarIsMissing));
            using (var assertContext = new AppDBContext(options))
            {
                var sut = new BarService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetBar(testBarID));
            }
        }


        [TestMethod]
        public async Task ReturnBarContract()
        {
            var testBarID = 1;
            
            var options = TestUtilities.GetOptions(nameof(ReturnBarContract));
            using (var arrangeContext = new AppDBContext(options))
            {
                arrangeContext.Bars.Add(new BarEntity() { Id = testBarID });
                arrangeContext.SaveChanges();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var bar = await sut.GetBar(testBarID);
                Assert.AreEqual(testBarID, bar.Id);
            }
        }
    }
}
