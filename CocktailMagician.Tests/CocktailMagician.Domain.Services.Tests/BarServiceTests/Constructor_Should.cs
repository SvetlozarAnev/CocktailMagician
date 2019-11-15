using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.BarServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void Returns_InstanceOfBarService()
        {
            var options = TestUtilities.GetOptions(nameof(Returns_InstanceOfBarService));

            using (var arrangeContext = new AppDBContext(options))
            {
                var barService = new BarService(arrangeContext);

                Assert.IsInstanceOfType(barService, typeof(BarService));

            }
        }
    }
}
