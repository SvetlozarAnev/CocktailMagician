using CocktailMagician.Contracts.Mappers;
using CocktailMagician.Contracts.Objects;
using CocktailMagician.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Mappers
{   
        public class CocktailReviewViewMapper : IViewModelMapper<CocktailReview, CocktailReviewViewModel>
        {
            public CocktailReviewViewModel MapFrom(CocktailReview entity)
    =>
        new CocktailReviewViewModel()
        {
            Id = entity.Id,
            UserEntityId = entity.UserEntityId,
            CocktailEntityId = entity.CocktailEntityId,
            Rating = entity.Rating,
            Review = entity.Review
        };
        }

}
