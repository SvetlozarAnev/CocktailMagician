using CocktailMagician.Contracts;
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

namespace CocktailMagician.Tests.CocktailMagician.Domain.Services.Tests.CocktailServiceTests
{
    [TestClass]
    public class CalculteAverageRating_Should
    {
        [TestMethod]
        public async Task ReturnCorrectCurrentRatingsCount()
        {
            const string testCocktailName = "TestCocktailName";
            const string testCocktailRecipe = "TestCocktailRecipe";
            
            const string testUserId1 = "userId1";
            const string testUserId2 = "userId2";
            const string testUserId3 = "userId3";

            const int testCocktailId = 3;
            const int testRating = 5;
            const int testNewRatingInt = 99;

            var cocktailReview1 = new CocktailReviewEntity()
            {
                UserEntityId = testUserId1,
                CocktailEntityId = testCocktailId,
                Rating = testRating
            };

            var cocktailReview2 = new CocktailReviewEntity()
            {
                UserEntityId = testUserId2,
                CocktailEntityId = testCocktailId,
                Rating = testRating
            };
            var cocktailReview3 = new CocktailReviewEntity()
            {
                UserEntityId = testUserId3,
                CocktailEntityId = testCocktailId,
                Rating = testRating
            };

            var options = TestUtilities.GetOptions(nameof(ReturnCorrectCurrentRatingsCount));

            var cocktail = new Cocktail()
            {
                Id = testCocktailId,
                Name = testCocktailName,
                Recipe = testCocktailRecipe,
            };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.CocktailReviews.AddAsync(cocktailReview1);
                await arrangeContext.CocktailReviews.AddAsync(cocktailReview2);
                await arrangeContext.CocktailReviews.AddAsync(cocktailReview3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                await sut.CalculateAverageRating(cocktail, testNewRatingInt);

                var currentRatingsCount = await actContext.CocktailReviews.Where(x => x.CocktailEntityId == cocktail.Id).CountAsync();

                Assert.AreEqual(3, currentRatingsCount);
            }
        }

        [TestMethod]
        public async Task ReturnCorrectCurrentRatingValue()
        {
            const string testCocktailName = "TestCocktailName";
            const string testCocktailRecipe = "TestCocktailRecipe";

            const string testUserId1 = "userId1";
            const string testUserId2 = "userId2";
            const string testUserId3 = "userId3";

            const int testCocktailId = 3;
            const int testNewRatingInt = 5;
            const int oldRatingsCount = 3;

            const int testRating1 = 1;
            const int testRating2 = 2;
            const int testRating3 = 5;

            var cocktailReview1 = new CocktailReviewEntity()
            {
                UserEntityId = testUserId1,
                CocktailEntityId = testCocktailId,
                Rating = testRating1
            };

            var cocktailReview2 = new CocktailReviewEntity()
            {
                UserEntityId = testUserId2,
                CocktailEntityId = testCocktailId,
                Rating = testRating2
            };
            var cocktailReview3 = new CocktailReviewEntity()
            {
                UserEntityId = testUserId3,
                CocktailEntityId = testCocktailId,
                Rating = testRating3
            };

            var options = TestUtilities.GetOptions(nameof(ReturnCorrectCurrentRatingValue));

            var cocktail = new Cocktail()
            {
                Id = testCocktailId,
                Name = testCocktailName,
                Rating = 2.67,
                Recipe = testCocktailRecipe,
            };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.CocktailReviews.AddAsync(cocktailReview1);
                await arrangeContext.CocktailReviews.AddAsync(cocktailReview2);
                await arrangeContext.CocktailReviews.AddAsync(cocktailReview3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new CocktailService(actContext);
                var rating = await sut.CalculateAverageRating(cocktail, testNewRatingInt);

                var expectedRating = ((cocktail.Rating) + (testNewRatingInt - cocktail.Rating) / (oldRatingsCount + 1));
                var expectedRatingRounded = Math.Round((double)expectedRating, 1);

                Assert.AreEqual(expectedRatingRounded, rating);
            }
        }
    }
}
