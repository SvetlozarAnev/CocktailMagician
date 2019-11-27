using CocktailMagician.Data;
using CocktailMagician.Data.Models;
using CocktailMagician.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.CocktailServiceTests
{
    [TestClass]
    public class GetCocktail_Should
    {
        [TestMethod]
        public async Task ThrowArgumentException_WhenCocktailIsMissing()
        {
            var testCocktailID = 1;
            var options = TestUtilities.GetOptions(nameof(ThrowArgumentException_WhenCocktailIsMissing));
            using (var assertContext = new AppDBContext(options))
            {
                var sut = new CocktailService(assertContext);
                await Assert.ThrowsExceptionAsync<ArgumentException>(() => sut.GetCocktail(testCocktailID));
            }
        }


        [TestMethod]
        public async Task ReturnCorrectCocktailContract()
        {
            var testCocktailID = 1;

            var options = TestUtilities.GetOptions(nameof(ReturnCorrectCocktailContract));
            using (var arrangeContext = new AppDBContext(options))
            {
                arrangeContext.Cocktails.Add(new CocktailEntity() { Id = testCocktailID });
                arrangeContext.SaveChanges();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                var cocktail = await sut.GetCocktail(testCocktailID);
                Assert.AreEqual(testCocktailID, cocktail.Id);
            }
        }

        //public async Task Retrun_AnInstanceOf_BarContract
        //{
        // var options = TestUtilities.GetOptions(nameof(ReturnBarContract));

    }



    //public async Task ThrowArgumentException_WhenInvalidParameterPassed

}