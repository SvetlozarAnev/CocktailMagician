using CocktailMagician.Contracts;
using CocktailMagician.Data;
using CocktailMagician.Domain.Mappers;
using CocktailMagician.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.UserServiceTests
{
    [TestClass]
    public class AddBarReview_Should
    {
        public async Task AddReviewToTheCorrectBar()
        {


            var testBarId = 2;
            var testUserId = "TestUserId";
            var testBarRating = 5;

            var testBarReview = new BarReview()
            {
                User = new User()
                {
                    Id = testUserId,
                    Name = "Pesho",
                    Email = "pesho@gosho.com"
                },

                Rating = testBarRating,
            };

            var options = TestUtilities.GetOptions(nameof(AddReviewToTheCorrectBar));


            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.BarReviews.AddAsync(testBarReview.ToEntity());
                await arrangeContext.SaveChangesAsync();
            }

            using (var assertContext = new AppDBContext(options))
            {
                var cocktailService = new CocktailService(assertContext);
                var barService = new BarService(assertContext);

                var sut = new UserService(assertContext, barService, cocktailService);



                var testReview = await sut.AddBarReview(testBarReview, testBarId, testUserId);

                Assert.AreEqual(testBarRating, testReview.Rating);


            }
        }
    }
}
