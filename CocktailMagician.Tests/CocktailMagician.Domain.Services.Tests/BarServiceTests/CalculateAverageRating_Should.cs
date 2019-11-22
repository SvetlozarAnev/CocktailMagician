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
    public class CalculateAverageRating_Should
    {
        [TestMethod]
        public async Task ReturnCorrectCurrentRatingsCount()
        {
            const string testBarName = "TestBarName";
            const string testBarAddress = "TestBarAddress";
            var testBarCocktails = new List<Cocktail>()
                {new Cocktail {Name = "testCocktail1", Recipe = "TestRecipe1", Ingredients = new List<Ingredient>()}};

            const string testUserId1 = "userId1";
            const string testUserId2 = "userId2";
            const string testUserId3 = "userId3";

            const int testBarId = 3;
            const int testRating = 5;
            const int testNewRatingInt = 99;

            var barReview1 = new BarReviewEntity()
            {
                UserEntityId = testUserId1,
                BarEntityId = testBarId,
                Rating = testRating
            };

            var barReview2 = new BarReviewEntity()
            {
                UserEntityId = testUserId2,
                BarEntityId = testBarId,
                Rating = testRating
            };
            var barReview3 = new BarReviewEntity()
            {
                UserEntityId = testUserId3,
                BarEntityId = testBarId,
                Rating = testRating
            };

            var options = TestUtilities.GetOptions(nameof(ReturnCorrectCurrentRatingsCount));

            var bar = new Bar()
            {
                Id = testBarId,
                Name = testBarName,
                Address = testBarAddress,
                Cocktails = testBarCocktails
            };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.BarReviews.AddAsync(barReview1);
                await arrangeContext.BarReviews.AddAsync(barReview2);
                await arrangeContext.BarReviews.AddAsync(barReview3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                await sut.CalculateAverageRating(bar, testNewRatingInt);

                var currentRatingsCount = await actContext.BarReviews.Where(x => x.BarEntityId == bar.Id).CountAsync();

                Assert.AreEqual(3, currentRatingsCount);
            }
        }

        [TestMethod]
        public async Task ReturnCorrectCurrentRatingValue()
        {
            const string testBarName = "TestBarName";
            const string testBarAddress = "TestBarAddress";
            var testBarCocktails = new List<Cocktail>()
                {new Cocktail {Name = "testCocktail1", Recipe = "TestRecipe1", Ingredients = new List<Ingredient>()}};
            
            const int testBarId = 3;
            const int testNewRatingInt = 5;
            const int oldRatingsCount = 3;

            const int testRating1 = 1;
            const int testRating2 = 2;
            const int testRating3 = 5;
            
            const string testUserId1 = "userId1";
            const string testUserId2 = "userId2";
            const string testUserId3 = "userId3";
            
            var barReview1 = new BarReviewEntity()
            {
                UserEntityId = testUserId1,
                BarEntityId = testBarId,
                Rating = testRating1
            };
            var barReview2 = new BarReviewEntity()
            {
                UserEntityId = testUserId2,
                BarEntityId = testBarId,
                Rating = testRating2
            };
            var barReview3 = new BarReviewEntity()
            {
                UserEntityId = testUserId3,
                BarEntityId = testBarId,
                Rating = testRating3
            };
            
            var options = TestUtilities.GetOptions(nameof(ReturnCorrectCurrentRatingValue));

            var bar = new Bar()
            {
                Id = testBarId,
                Name = testBarName,
                Address = testBarAddress,
                Rating = 2.67,
                Cocktails = testBarCocktails
            };

            using (var arrangeContext = new AppDBContext(options))
            {
                await arrangeContext.BarReviews.AddAsync(barReview1);
                await arrangeContext.BarReviews.AddAsync(barReview2);
                await arrangeContext.BarReviews.AddAsync(barReview3);
                await arrangeContext.SaveChangesAsync();
            }

            using (var actContext = new AppDBContext(options))
            {
                var sut = new BarService(actContext);
                var rating = await sut.CalculateAverageRating(bar, testNewRatingInt);

                var expectedRating = ((bar.Rating) + (testNewRatingInt - bar.Rating) / (oldRatingsCount + 1));
                var expectedRatingRounded = Math.Round((double)expectedRating, 1);

                Assert.AreEqual(expectedRatingRounded, rating);
            }
        }
    }
}
